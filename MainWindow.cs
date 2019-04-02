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

namespace Invertor
{
    public partial class MainWindow : Form
    {
        List<Object> objectsInSketch;
        
        Point firstLastPoint, secondLastPoint, Origin;

        Bitmap bmp;
        Graphics g;

        string selectedTool = "";
        List<object> toolControlsList = new List<object>();

        public MainWindow()
        {
            InitializeComponent();
            
            // list of all objects
            objectsInSketch = new List<Object>();
            Origin = new Point("Origin", 100, 100, 3);
            objectsInSketch.Add(Origin);
            refreshObjectListView();

            //declare working bitmap
            bmp = new Bitmap(5000, 3000);
            //declare graphics
            g = Graphics.FromImage(bmp);
            //AA on
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
           
            //last selected points on screen
            firstLastPoint = null;
            secondLastPoint = null;

            //add all tool controls to the list
            toolControlsList.Add(lineButton);

            //reset point
            firstLastPointLabelValue.Text = "";
            secondLastPointLabelValue.Text = "";

        }

        #region toolControl

        private void lineButton_CheckedChanged(object sender, EventArgs e)
        {
            resetSelectedTool(lineButton);
            if (lineButton.Checked)
                selectedTool = "line";
        }

        void resetSelectedTool(CheckBox sender)
        {
            foreach(CheckBox o in toolControlsList)
            {
                if (o != sender)
                    o.Checked = false;
            }
            selectedTool = "";
        }

        #endregion

        #region tools


        private void drawingArea_Click(object sender, EventArgs e)
        {
            if(selectedTool != "")
            {
                //save the mouse's position
                System.Drawing.Point mouse = drawingArea.PointToClient(new System.Drawing.Point(MousePosition.X - Origin.X, MousePosition.Y - Origin.Y));
                firstLastPoint = new Point("",mouse);

                if (secondLastPoint == null)//if it is the first click
                {
                    secondLastPoint = firstLastPoint;
                    firstLastPoint = null;
                }
                else
                {
                    switch (selectedTool) //tool switch
                    {
                        case "line":
                            //create new line and two points
                            objectsInSketch.Add(new Point("point" + countObjectsOfType(typeof(Point)), firstLastPoint.X, firstLastPoint.Y));
                            objectsInSketch.Add(new Point("point" + countObjectsOfType(typeof(Point)), secondLastPoint.X, secondLastPoint.Y));
                            objectsInSketch.Add(new Line("line" + countObjectsOfType(typeof(Line)),secondLastPoint, firstLastPoint, 1));

                            break;
                        case "rectangle":

                            break;
                            
                    }

                    //set last points to null
                    firstLastPoint = null;
                    secondLastPoint = null;
                }
            }

            //redraw the form
            drawingArea.Invalidate();

            refreshObjectListView();

            //set point labels
            if (firstLastPoint != null)
                firstLastPointLabelValue.Text = firstLastPoint.ToString();
            else
                firstLastPointLabelValue.Text = "";
            if (secondLastPoint != null)
                secondLastPointLabelValue.Text = secondLastPoint.ToString();
            else
                secondLastPointLabelValue.Text = "";
        }

        private void drawingArea_Paint(object sender, PaintEventArgs e)
        {
            foreach (Object O in objectsInSketch)
            {

                O.Render(g,bmp,Origin);
            }

            e.Graphics.DrawImage(bmp, 0, 0);
        }

        
        #endregion

        #region keybinding

        //key input
        private void MainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            MessageBox.Show(e.KeyCode.ToString());
            switch (e.KeyCode.ToString())
            {
                case "L":
                    selectedTool = "line";
                    break;
                case "Escape":
                    resetSelectedTool(null);
                    break;
            }
        }
        

        private void MainWindow_KeyPress(object sender, KeyPressEventArgs e)
        {
            MessageBox.Show(e.KeyChar.ToString());
            switch (e.KeyChar.ToString())
            {
                case "L":
                    selectedTool = "line";
                    break;
                case "Escape":
                    resetSelectedTool(null);
                    break;
            }
        }

        #endregion

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

    }
}
