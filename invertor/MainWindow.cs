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
using System.Threading;
using System.Timers;

namespace Invertor
{

    public partial class MainWindow : Form
    {
        List<Object> objectsInSketch;

        Point firstLastPoint, secondLastPoint, origin;
        double scale = 1;
        bool draging = false;

        Graphics g;
        Bitmap bmp = new Bitmap(2000, 2000);

        Thread renderThread;
        System.Timers.Timer renderTimer = new System.Timers.Timer();
        Thread tiesThread;

        string selectedTool = "";
        List<object> toolControlsList = new List<object>();
        Point mousePoint = new Point("mousePoint", 0, 0);

        public MainWindow()
        {
            InitializeComponent();

            renderThread = new Thread(renderCycle);
            g = Graphics.FromImage(bmp);
            tiesThread = new Thread(resolveTies);

            // list of all objects
            objectsInSketch = new List<Object>();
            origin = new Point("origin", 0, 0, 3);
            objectsInSketch.Add(origin);
            refreshObjectListView();

            //last selected points on screen
            firstLastPoint = null;
            secondLastPoint = null;

            //add all tool controls to the list
            toolControlsList.Add(lineButton);
            toolControlsList.Add(rectangleButton);
            toolControlsList.Add(circleButton);

            //reset point
            secondLastPointLabelValue.Text = "";

            //keybinding
            this.KeyPreview = true;

            //set the dialogs
            saveFileDialog.Filter = "vector files (*.vec)|*.inv|All files (*.*)|*.*";
            openFileDialog.Filter = "vector files (*.vec)|*.inv";

            renderThread.Start();
        }

        #region toolControl

        private void toolChecked(object sender, EventArgs e)
        {
            CheckBox pressed = sender as CheckBox;
            if (pressed.Checked)
            {
                resetselectedTool(pressed);
                selectedTool = pressed.Text.ToLower();
            }
        }

        void resetselectedTool(CheckBox sender)
        {
            foreach (CheckBox o in toolControlsList)
            {
                if (o != sender)
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
            if (MouseButtons.Right == ((MouseEventArgs)e).Button)
            {
                selectedTool = "";
                resetselectedTool(null);
            }

            setTopLabel();
            this.Text += "*";
            drawingArea.Focus();

            if (selectedTool != "")
            {
                //use the mouse point in order to allow point snapping
                firstLastPoint = mousePoint;

                if (secondLastPoint == null)//if it is the first click
                {
                    secondLastPoint = firstLastPoint;
                    firstLastPoint = null;
                    secondLastPoint = pointSnapping(secondLastPoint);

                    //reset the lenght input
                    prewievLenghtValue.Text = "";

                }
                else
                {
                    switch (selectedTool) //tool switch
                    {
                        case "line":
                            if (!objectsInSketch.Contains(secondLastPoint))
                                secondLastPoint = addPoint(secondLastPoint.systemPoint);
                            if (!objectsInSketch.Contains(firstLastPoint))
                                firstLastPoint = addPoint(firstLastPoint.systemPoint);
                            addLine(secondLastPoint, firstLastPoint);
                            break;
                        case "rectangle":
                            if (!objectsInSketch.Contains(firstLastPoint))
                                firstLastPoint = addPoint(firstLastPoint.systemPoint);
                            if (!objectsInSketch.Contains(secondLastPoint))
                                secondLastPoint = addPoint(secondLastPoint.systemPoint);

                            Point p0 = addPoint(new System.Drawing.Point(secondLastPoint.X, firstLastPoint.Y));
                            Point p1 = addPoint(new System.Drawing.Point(firstLastPoint.X, secondLastPoint.Y));

                            Line l0 = addLine(firstLastPoint, p0);
                            Line l1 = addLine(firstLastPoint, p1);
                            Line l2 = addLine(p0, secondLastPoint);
                            Line l3 = addLine(p1, secondLastPoint);

                            //add parael ties
                            //l0.ParaelLines.Add(l3);
                            //l3.ParaelLines.Add(l0);
                            //l2.ParaelLines.Add(l1);
                            l1.ParaelLines.Add(l2);

                            //add perpendicular ties
                            l0.PerpLines.Add(l1);
                            l0.PerpLines.Add(l2);
                            l1.PerpLines.Add(l0);
                            l1.PerpLines.Add(l3);
                            l2.PerpLines.Add(l0);
                            l2.PerpLines.Add(l3);
                            l3.PerpLines.Add(l1);
                            l3.PerpLines.Add(l2);

                            break;
                        case "circle":
                            if (!objectsInSketch.Contains(secondLastPoint))
                                secondLastPoint = addPoint(secondLastPoint.systemPoint);
                            addCircle(secondLastPoint, firstLastPoint.distance(secondLastPoint));
                            break;
                    }

                    //if tool require it, set last point to second one
                    if (selectedTool == "line")
                        secondLastPoint = firstLastPoint;
                    else
                        secondLastPoint = null;
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

        private void paraelButton_Click(object sender, EventArgs e)
        {
            ListBox.SelectedObjectCollection selected = objectListView.SelectedItems;

            foreach (Object o in selected)
                if (o.GetType() != typeof(Line))
                    MessageBox.Show("Invalid object " + o.Name + " expecting Lines");
                else
                    (o as Line).ParaelLines.Add(o as Line);
            
        }

        private void drawingArea_MouseUp(object sender, EventArgs e)
        {
            draging = false;
            refreshLabels();
            //resolveTies();
        }

    
        private void drawingArea_MouseDown(object sender, MouseEventArgs e)
        {
            if (selectedTool != "")
                return;
            draging = true;

            Point p = pointSnapping(mousePoint);
            if(p.Name != "mousePoint")
                objectListView.SelectedItem = p;
        }
        

        private void selectBackColorButton_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                selectBackColor.BackColor = colorDialog.Color;
                drawingArea.BackColor = selectBackColor.BackColor;
            }
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

        Line addLine(Point start, Point end)
        {
            Line l = new Line("line" + countObjectsOfType(typeof(Line)), start, end, (int)lineThicknessValue.Value, lineColorPicture.BackColor);
            objectsInSketch.Add(l);
            return l;
        }

        void addCircle(Point center, double radius)
        {
            objectsInSketch.Add(new Circle("circle" + countObjectsOfType(typeof(Circle)), center, radius, colorDialog.Color));
        }

        private void objectListView_DoubleClick(object sender, EventArgs e)
        {
            IEnumerable<Object> o = objectsInSketch.Where(c => c.Name == objectListView.SelectedItem.ToString().Split(':')[0]);
            //show the edit panel with o.first as object of interest
        }

        #endregion

        #region rendering
        private void drawingArea_MouseMove(object sender, MouseEventArgs e)
        {
            Point newPoint = new Point((int)((drawingArea.PointToClient(MousePosition).X - origin.X) / scale), (int)((drawingArea.PointToClient(MousePosition).Y - origin.Y) / scale));

            if (draging == true)
            {
                //(objectListView.SelectedItem as Point).fromSystemPoint(newPoint.systemPoint);
                
            }else if(MouseButtons.Left == MouseButtons && selectedTool == ""){
                origin.X += newPoint.X - mousePoint.X;
                origin.Y += newPoint.Y - mousePoint.Y;
            }

            mousePoint = newPoint.Clone();
        }

        public void renderCycle()
        {
            renderTimer.Interval = (int)(1000 / fpsValue.Value);
            renderTimer.Elapsed += render;
            renderTimer.Start();
        }

        void render(object sender, EventArgs e)
        {
            //declare new bitmap  and graphics
            g = Graphics.FromImage(bmp);
            g.Clear(Color.Transparent);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            //draw all objects
            foreach (Object O in objectsInSketch)
            {
                O.Render(g, bmp, origin, scale);
            }

            //draw snapping point -> just draw
            Point a = pointSnapping(mousePoint);
            if (a != null)
            {
                g.DrawRectangle(new Pen(colorDialog.Color, 5), new Rectangle(new System.Drawing.Point((int)(scale * a.X) + origin.X, (int)(scale * a.Y) + origin.Y), new Size(1, 1)));
                mousePoint = a;
            }

            highlightSelected();

            //if draging, draw to mouse position
            if (secondLastPoint != null)
                renderDraging();

            //set drawing area as a drawn bitmap
            drawingArea.Image = bmp;
            //update fps counter
            renderTimer.Interval = (int)(1000 / fpsValue.Value);
        }

        void renderDraging()
        {
            switch (selectedTool)
            {
                case "line":
                    g.DrawLine(new Pen(lineColorPicture.BackColor, (int)lineThicknessValue.Value), new System.Drawing.Point((int)(scale * secondLastPoint.X) + origin.X, (int)(scale * secondLastPoint.Y) + origin.Y), new System.Drawing.Point((int)(mousePoint.X * scale) + origin.X, (int)(mousePoint.Y * scale) + origin.Y));
                    break;
                case "rectangle":
                    Rectangle r = new Rectangle(Math.Min(((int)(scale * secondLastPoint.X) + origin.X), mousePoint.X), Math.Min(((int)(scale * secondLastPoint.Y) + origin.Y), mousePoint.Y), (int)(Math.Abs(mousePoint.X - secondLastPoint.X)*scale), (int)(Math.Abs(mousePoint.Y - secondLastPoint.Y)*scale));
                    g.DrawRectangle(new Pen(lineColorPicture.BackColor, (int)lineThicknessValue.Value), r);
                    break;
                case "circle":
                    int Diameter = (int)mousePoint.distance(secondLastPoint);
                    g.DrawEllipse(new Pen(lineColorPicture.BackColor), new Rectangle(new System.Drawing.Point((int)(scale * (secondLastPoint.X - Diameter)) + origin.X, (int)(scale * (secondLastPoint.Y - Diameter)) + origin.Y), new Size((int)((Diameter + Diameter)*scale), (int)((Diameter + Diameter)*scale))));
                    break;
            }
        }

        void highlightSelected()
        {
            ListBox.SelectedObjectCollection selected = objectListView.SelectedItems;

            foreach (Object o in selected)
                o.highlight(g,bmp,origin,scale,Color.Black);
        }

        Point pointSnapping(Point p)
        {
            foreach (Object O in objectsInSketch)
            {
                if (O.GetType() == typeof(Point))
                {
                    if (isInDistancePoints((O as Point).systemPoint, p.systemPoint, 10 / scale))
                        return O as Point;
                }
            }
            return p;
        }

        bool isInDistancePoints(System.Drawing.Point pointA, System.Drawing.Point pointB, double maxDistance)
        {
            return ((pointA.X - pointB.X) * (pointA.X - pointB.X) + (pointA.Y - pointB.Y) * (pointA.Y - pointB.Y)) < maxDistance * maxDistance;
        }

        private void drawingArea_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta > 1)
            {
                if (scale > 0.2)
                    scale += (double)(scaleStepValue.Value / 100);
                else
                    scale *= 1.5;
            }
            else
            {
                if (scale > 0.2)
                    scale -= (double)(scaleStepValue.Value / 100);
                else
                    scale /= 1.5;
            }
            refreshLabels();
        }


        #endregion

        void resolveTies()
        {
            foreach (Object o in objectsInSketch)
                o.resolveTies();
            refreshLabels();
        }

        //keybinding
        private void MainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (Control.ModifierKeys == Keys.Control)
            {//cotrol + 
                switch (e.KeyCode)
                {
                    case Keys.Add:
                        if (scale > 0.2)
                            scale += (double)(scaleStepValue.Value / 100);
                        else
                            scale *= 1.5;
                        refreshLabels();
                        break;
                    case Keys.Subtract:
                        if (scale > 0.2)
                            scale -= (double)(scaleStepValue.Value / 100);
                        else
                            scale /= 1.5;
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
                    //numbers to input
                    case Keys.NumPad0:
                        prewievLenghtValue.Text += "0";
                        break;
                    case Keys.NumPad1:
                        prewievLenghtValue.Text += "1";
                        break;
                    case Keys.NumPad2:
                        prewievLenghtValue.Text += "2";
                        break;
                    case Keys.NumPad3:
                        prewievLenghtValue.Text += "3";
                        break;
                    case Keys.NumPad4:
                        prewievLenghtValue.Text += "4";
                        break;
                    case Keys.NumPad5:
                        prewievLenghtValue.Text += "5";
                        break;
                    case Keys.NumPad6:
                        prewievLenghtValue.Text += "6";
                        break;
                    case Keys.NumPad7:
                        prewievLenghtValue.Text += "7";
                        break;
                    case Keys.NumPad8:
                        prewievLenghtValue.Text += "8";
                        break;
                    case Keys.NumPad9:
                        prewievLenghtValue.Text += "9";
                        break;

                    case Keys.L:
                        toggleTool(lineButton);
                        break;
                    case Keys.R:
                        toggleTool(rectangleButton);
                        break;
                    case Keys.C:
                        toggleTool(circleButton);
                        break;
                    case Keys.Escape:
                        resetselectedTool(null);
                        break;
                    case Keys.Enter:
                        if (selectedTool == "circle")
                            setCircleByDiameter();
                        firstLastPoint = null;
                        secondLastPoint = null;
                        break;
                    case Keys.Up:
                        if (invertedDirectionCheckbox.Checked)
                            origin.Y += (int)((double)originMovementStepValue.Value * scale);
                        else
                            origin.Y -= (int)((double)originMovementStepValue.Value * scale);
                        break;
                    case Keys.Down:
                        if (invertedDirectionCheckbox.Checked)
                            origin.Y -= (int)((double)originMovementStepValue.Value * scale);
                        else
                            origin.Y += (int)((double)originMovementStepValue.Value * scale);
                        break;
                    case Keys.Left:
                        if (invertedDirectionCheckbox.Checked)
                            origin.X += (int)((double)originMovementStepValue.Value * scale);
                        else
                            origin.X -= (int)((double)originMovementStepValue.Value * scale);
                        break;
                    case Keys.Right:
                        if (invertedDirectionCheckbox.Checked)
                            origin.X -= (int)((double)originMovementStepValue.Value * scale);
                        else
                            origin.X += (int)((double)originMovementStepValue.Value * scale);
                        break;
                }
            }

            refreshObjectListView();
        }

        void setCircleByDiameter()
        {
            if (!objectsInSketch.Contains(secondLastPoint))
                secondLastPoint = addPoint(secondLastPoint.systemPoint);
            addCircle(secondLastPoint, int.Parse(prewievLenghtValue.Text));
            secondLastPoint = null;
            firstLastPoint = null;
            prewievLenghtValue.Text = "";
        }

        #region Form events

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.Text.Contains("*")) { 
                DialogResult Result = MessageBox.Show("Do you want to save the file?", "Quit application", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                if (Result == DialogResult.Cancel)
                    e.Cancel = true;
                else if (Result == DialogResult.Yes)
                {
                    saveJson(saveFileDialog.FileName);
                }
            }
        }

        private void fileSaveAsButton_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
                saveJson(saveFileDialog.FileName);
            setTopLabel();
        }

        private void fileSaveButton_Click(object sender, EventArgs e)
        {
            if (this.Text.Contains("*"))
                fileSaveAsButton_Click(sender, e);
            else
                saveJson(saveFileDialog.FileName);
            setTopLabel();
        }

        void setTopLabel()
        {
            this.Text = Path.GetFileName(saveFileDialog.FileName);
        }

        private void fileNewButton_Click(object sender, EventArgs e)
        {
            objectsInSketch.Clear();
            origin = new Point("origin", 0, 0, 3);
            objectsInSketch.Add(origin);
            refreshObjectListView();

            //last selected points on screen
            firstLastPoint = null;
            secondLastPoint = null;

            saveFileDialog.FileName = "";
            openFileDialog.FileName = "";
            setTopLabel();
        }

        private void fileOpenButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                objectsInSketch.Clear();
                openJson(openFileDialog.FileName);
            }

            saveFileDialog.FileName = openFileDialog.FileName;
            setTopLabel();
        }

        #endregion

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

            try
            {
                string[] lines = file.Split('\n');

                for (int i = 0; i < lines.Length - 1; i++) //point round
                {
                    if (lines[i].Split('{')[0] == "Point")
                    {
                        Point p = new Point(lines[i].Split('{')[1].Split('}')[0]);
                        objectsInSketch.Add(p);
                        if (p.Name == "origin")
                            origin = p;
                    }

                }
                for (int i = 0; i < lines.Length - 1; i++) //line round
                {
                    if (lines[i].Split('{')[0] == "Line")
                    {
                        Line l = new Line(lines[i].Split('{')[1].Split('}')[0]);

                        Object p0 = objectsInSketch.Where(x => x.Name == l.StartPoint.Name).First();
                        Object p1 = objectsInSketch.Where(x => x.Name == l.EndPoint.Name).First();

                        l.StartPoint = p0 as Point;
                        l.EndPoint = p1 as Point;

                        objectsInSketch.Add(l);
                    }
                }
                for (int i = 0; i < lines.Length - 1; i++) //circle round
                {
                    if (lines[i].Split('{')[0] == "Circle")
                    {
                        Circle c = new Circle(lines[i].Split('{')[1].Split('}')[0]);

                        Object p = objectsInSketch.Where(x => x.Name == c.Center.Name).First();

                        c.Center = p as Point;

                        objectsInSketch.Add(c);
                    }
                }
            }
            catch
            {
                MessageBox.Show("Invalid file");
            }

            refreshObjectListView();
        }

        #endregion

        #region info

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

        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            resolveTies();
        }
        
        IEnumerable<Object> findClass(Object @class)
        {
            return objectsInSketch.Where(c => c.GetType() == @class.GetType());
        }

        int countObjectsOfType(Type t)
        {
            int count = 0;
            foreach (Object O in objectsInSketch)
            {
                if (O.GetType() == t)
                    count++;
            }
            return count;
        }

    }
}
