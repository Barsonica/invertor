using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using System.IO;
using System.Xml.Serialization;

namespace Invertor
{

    public partial class MainWindow : Form
    {
        List<Object> objectsInSketch;
        
        Point firstLastPoint, secondLastPoint, Origin;

        Bitmap bmp;
        Graphics g;
        double scale = 1;

        string selectedTool = "";
        List<object> toolControlsList = new List<object>();
        Point mousePoint = new Point("mousePoint", 0, 0);

        public MainWindow()
        {
            InitializeComponent();

            bmp = new Bitmap(2000, 2000);

            // list of all objects
            objectsInSketch = new List<Object>();
            Origin = new Point("Origin", 0, 0, 3);
            objectsInSketch.Add(Origin);
            refreshObjectListView();

            //last selected points on screen
            firstLastPoint = null;
            secondLastPoint = null;

            //add all tool controls to the list
            toolControlsList.Add(lineButton);

            //reset point
            secondLastPointLabelValue.Text = "";

            //keybinding
            this.KeyPreview = true;

            //set the dialogs
            saveFileDialog.Filter = "vector files (*.vec)|*.inv|All files (*.*)|*.*";
            openFileDialog.Filter = "vector files (*.vec)|*.inv";

            renderTimer.Start();

        }

        #region toolControl

        private void lineButton_CheckedChanged(object sender, EventArgs e)
        {
            if (lineButton.Checked)
            {
                resetSelectedTool(lineButton);
                selectedTool = "line";
            }
        }

        private void rectangleButton_CheckedChanged(object sender, EventArgs e)
        {
            if (rectangleButton.Checked)
            {
                resetSelectedTool(rectangleButton);
                selectedTool = "rectangle";
            }
        }

        void resetSelectedTool(CheckBox sender)
        {
            foreach(CheckBox o in toolControlsList)
            {
                if(o != sender)
                    o.Checked = false;
            }
            selectedTool = "";

            //reset the selected points
            firstLastPoint = null;
            secondLastPoint = null;
        }

        void toggleTool(CheckBox tool)
        {
            if (tool.Checked)
            {
                tool.Checked = false;
                selectedTool = "";
            }
            else
            {
                tool.Checked = true;
                selectedTool = tool.Text.ToLower();
            }
                
        }

        #endregion

        #region tools

        private void drawingArea_Click(object sender, EventArgs e)
        {
            drawingArea.Focus();

            if(selectedTool != "")
            {
                //use the mouse point in order to allow point snapping
                firstLastPoint = mousePoint;

                if (secondLastPoint == null)//if it is the first click
                {
                    secondLastPoint = firstLastPoint;
                    firstLastPoint = null;
                    objectsInSketch.Add(secondLastPoint);

                }
                else
                {
                    switch (selectedTool) //tool switch
                    {
                        case "line":
                            //firstLastPoint = addPoint(firstLastPoint.systemPoint);
                            if(!objectsInSketch.Contains(firstLastPoint))
                                objectsInSketch.Add(firstLastPoint);
                            addLine(firstLastPoint,secondLastPoint);
                            break;
                        case "rectangle":
                            if (!objectsInSketch.Contains(firstLastPoint))
                                objectsInSketch.Add(firstLastPoint);
                            Point p0 = addPoint(new System.Drawing.Point(secondLastPoint.X,firstLastPoint.Y));
                            addLine(firstLastPoint,p0);
                            Point p1 = addPoint(new System.Drawing.Point(firstLastPoint.X, secondLastPoint.Y));
                            addLine(firstLastPoint,p1);
                            addLine(secondLastPoint,p0);
                            addLine(secondLastPoint,p1);
                            break;
                            
                    }

                    //set last point to second one
                    secondLastPoint = firstLastPoint;
                    firstLastPoint = null;
                }
            }
            
            refreshObjectListView();

            //set point label
            if (secondLastPoint != null)
                secondLastPointLabelValue.Text = secondLastPoint.ToString();
            else
                secondLastPointLabelValue.Text = "";
        }

        private void lineColorButton_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
                lineColorPicture.BackColor = colorDialog.Color;
        }

        Point addPoint(System.Drawing.Point location)
        {
            Point p = new Point("point" + countObjectsOfType(typeof(Point)), location.X, location.Y);
            objectsInSketch.Add(p);
            return p;
        }

        void addLine(Point start, Point end)
        {
            objectsInSketch.Add(new Line("line" + countObjectsOfType(typeof(Line)), start, end, (int)lineThicknessValue.Value,lineColorPicture.BackColor));
        }

        #endregion

        #region rendering
        
        //render loop
        private void renderTimer_Tick(object sender, EventArgs e)
        {
            //get mouse position before any adjustments
            mousePoint = new Point("point" + countObjectsOfType(typeof(Point)).ToString(), (int)((drawingArea.PointToClient(MousePosition).X - Origin.X) / scale), (int)((drawingArea.PointToClient(MousePosition).Y - Origin.Y) / scale));

            //declare new bitmap  and graphics
            g = Graphics.FromImage(bmp);
            g.Clear(Color.Transparent);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            //draw all objects
            foreach (Object O in objectsInSketch)
            {
                O.Render(g, bmp, Origin, scale);
            }

            //draw snapping point -> just draw
            Point a = pointSnapping(mousePoint.systemPoint);
            if (a != null)
            {
                g.DrawRectangle(new Pen(colorDialog.Color, 5), new Rectangle(new System.Drawing.Point((int)(scale * a.X) + Origin.X, (int)(scale * a.Y) + Origin.Y), new Size(1, 1)));
                mousePoint = a;
            }

            //if draging line, draw to mouse position
            if (secondLastPoint != null)
                renderDraging();

            //set drawing area as a drawn bitmap
            drawingArea.Image = bmp;
        }
        
        //render active line to mouse
        void renderDraging()
        {
            switch (selectedTool)
            {
                case "line":
                    g.DrawLine(new Pen(lineColorPicture.BackColor, (int)lineThicknessValue.Value), new System.Drawing.Point((int)(scale * secondLastPoint.X) + Origin.X, (int)(scale * secondLastPoint.Y) + Origin.Y), new System.Drawing.Point((int)(mousePoint.X * scale) + Origin.X, (int)(mousePoint.Y * scale) + Origin.Y));
                    break;
                case "rectangle":
                    Rectangle r = new Rectangle(Math.Min(((int)(scale * secondLastPoint.X) + Origin.X), mousePoint.X), Math.Min(((int)(scale * secondLastPoint.Y) + Origin.Y), mousePoint.Y), Math.Abs(mousePoint.X - secondLastPoint.X), Math.Abs(mousePoint.Y - secondLastPoint.Y));
                    g.DrawRectangle(new Pen(lineColorPicture.BackColor, (int)lineThicknessValue.Value),r);
                    break;
            }
        }

        #endregion

        //keybinding
        private void MainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if(Control.ModifierKeys == Keys.Control)
            {//cotrol + 
                switch (e.KeyCode)
                {
                    case Keys.Add:
                        scale+=(double)(scaleStepValue.Value/100);
                        refreshLabels();
                        break;
                    case Keys.Subtract:
                        if (scale > 0.2)
                            scale -= (double)(scaleStepValue.Value / 100);
                        else
                            scale/=1.5;
                        refreshLabels();
                        break;
                    case Keys.S:
                        fileSaveButton_Click(sender, new EventArgs());
                        break;
                    case Keys.O:
                        fileOpenButton_Click(sender, new EventArgs());
                        break;
                    case Keys.N:
                        fileNewButton_Click(sender, new EventArgs());
                        break;
                }
            }
            else
            {
                switch (e.KeyCode)
                {
                    case Keys.L:
                        toggleTool(lineButton);
                        break;
                    case Keys.Escape:
                        resetSelectedTool(null);
                        break;
                    case Keys.Enter:
                        firstLastPoint = null;
                        secondLastPoint = null;
                        break;
                    case Keys.Up:
                        if(invertedDirectionCheckbox.Checked)
                            Origin.Y += (int)((double)originMovementStepValue.Value * scale);
                        else
                            Origin.Y -= (int)((double)originMovementStepValue.Value * scale);
                        break;
                    case Keys.Down:
                        if (invertedDirectionCheckbox.Checked)
                            Origin.Y -= (int)((double)originMovementStepValue.Value * scale);
                        else
                            Origin.Y += (int)((double)originMovementStepValue.Value * scale);
                        break;
                    case Keys.Left:
                        if (invertedDirectionCheckbox.Checked)
                            Origin.X += (int)((double)originMovementStepValue.Value * scale);
                        else
                            Origin.X -= (int)((double)originMovementStepValue.Value * scale);
                        break;
                    case Keys.Right:
                        if (invertedDirectionCheckbox.Checked)
                            Origin.X -= (int)((double)originMovementStepValue.Value * scale);
                        else
                            Origin.X += (int)((double)originMovementStepValue.Value * scale);
                        break;
                }
            }

            refreshObjectListView();   
        }

        #region file operations

        void saveJson(string path)
        {
            string file = "";
            using (StreamWriter sw = new StreamWriter(new FileStream(path, FileMode.Create)))
            {
                foreach (Object O in objectsInSketch)
                {
                    sw.WriteLine(O.GetType().Name + "{" + O.toJson() + "}");
                }

                sw.Write(file);
                sw.Flush();
            }
        }

        void openJson(string path)
        {
            string file = "";
            using (StreamReader sr = new StreamReader(new FileStream(path, FileMode.Open)))
            {
                file = sr.ReadToEnd();
            }

            string[] lines = file.Split('\n');

            for (int i = 0; i < lines.Length - 1; i++)
            {
                switch (lines[i].Split('{')[0])
                {
                    case "Point":
                        Point p = new Point(lines[i].Split('{')[1].Split('}')[0]);
                        objectsInSketch.Add(p);
                        if (p.Name == "Origin")
                            Origin = p;
                        break;
                    case "Line":
                        Line l = new Line(lines[i].Split('{')[1].Split('}')[0]);

                        Object p0 = objectsInSketch.Where(x => x.Name == l.StartPoint.Name).First();
                        Object p1 = objectsInSketch.Where(x => x.Name == l.EndPoint.Name).First();

                        l.StartPoint = p0 as Point;
                        l.EndPoint = p1 as Point;

                        objectsInSketch.Add(l);
                        break;
                }
            }
            refreshObjectListView();
        }

        private void fileSaveButton_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
                saveJson(saveFileDialog.FileName);

            
        }

        private void fileNewButton_Click(object sender, EventArgs e)
        {
            objectsInSketch.Clear();
            Origin = new Point("Origin", 0, 0, 3);
            objectsInSketch.Add(Origin);
            refreshObjectListView();

            //last selected points on screen
            firstLastPoint = null;
            secondLastPoint = null;
        }

        private void fileOpenButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                objectsInSketch.Clear();
                openJson(openFileDialog.FileName);
            }
        }

        #endregion

        IEnumerable<Object> findClass(Object @class)
        {
            return objectsInSketch.Where(c => c.GetType() == @class.GetType());
        }

        Point pointSnapping(System.Drawing.Point p)
        {
            foreach (Object O in objectsInSketch)
            {
                if (O.GetType() == typeof(Point))
                {
                    if (isInDistancePoints((O as Point).systemPoint, p, 10 / scale))
                        return O as Point;
                }
            }
            return null;
        }

        void refreshLabels()
        {
            scaleLabelValue.Text = ((int)(scale / 0.01)).ToString() + "%";
        }

        void refreshObjectListView()
        {
            objectListView.Items.Clear();
            foreach (Object O in objectsInSketch)
                objectListView.Items.Add(O);
        }

        int countObjectsOfType(Type t)
        {
            int count = 0;
            foreach(Object O in objectsInSketch)
            {
                if (O.GetType() == t)
                    count++;
            }
            return count;
        }

        bool isInDistancePoints(System.Drawing.Point pointA, System.Drawing.Point pointB, double maxDistance)
        {
            return ((pointA.X - pointB.X) * (pointA.X - pointB.X) + (pointA.Y - pointB.Y) * (pointA.Y - pointB.Y)) < maxDistance * maxDistance;
        }

    }
}
