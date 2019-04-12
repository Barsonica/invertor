using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Invertor
{
    public class renderer
    {
        MainWindow parent;
        Bitmap bmp;
        Graphics g;


        public renderer(MainWindow Parent)
        {
            parent = Parent;
            bmp = new Bitmap(2000, 2000);
        }

        public void renderCycle()
        {

        }

        void render()
        {
            //declare new bitmap  and graphics
            g = Graphics.FromImage(bmp);
            g.Clear(Color.Green);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            //draw all objects
            foreach (Object O in parent.ObjectsInSketch)
            {
                O.Render(g, bmp, parent.Origin, parent.Scale);
            }

            //draw snapping point -> just draw
            Point a = pointSnapping(parent.MousePoint.systemPoint);
            if (a != null)
            {
                g.DrawRectangle(new Pen(parent.colorDialog.Color, 5), new Rectangle(new System.Drawing.Point((int)(parent.Scale * a.X) + parent.Origin.X, (int)(parent.Scale * a.Y) + parent.Origin.Y), new Size(1, 1)));
                parent.MousePoint = a;
            }

            //if draging line, draw to mouse position
            if (parent.SecondLastPoint != null)
                renderDraging();

            //set drawing area as a drawn bitmap
            parent.drawingArea.Image = bmp;
        }

        void renderDraging()
        {
            switch (parent.SelectedTool)
            {
                case "line":
                    g.DrawLine(new Pen(parent.lineColorPicture.BackColor, (int)parent.lineThicknessValue.Value), new System.Drawing.Point((int)(parent.Scale * parent.SecondLastPoint.X) + parent.Origin.X, (int)(parent.Scale * parent.SecondLastPoint.Y) + parent.Origin.Y), new System.Drawing.Point((int)(parent.MousePoint.X * parent.Scale) + parent.Origin.X, (int)(parent.MousePoint.Y * parent.Scale) + parent.Origin.Y));
                    break;
                case "rectangle":
                    Rectangle r = new Rectangle(Math.Min(((int)(parent.Scale * parent.SecondLastPoint.X) + parent.Origin.X), parent.MousePoint.X), Math.Min(((int)(parent.Scale * parent.SecondLastPoint.Y) + parent.Origin.Y), parent.MousePoint.Y), Math.Abs(parent.MousePoint.X - parent.SecondLastPoint.X), Math.Abs(parent.MousePoint.Y - parent.SecondLastPoint.Y));
                    g.DrawRectangle(new Pen(parent.lineColorPicture.BackColor, (int)parent.lineThicknessValue.Value), r);
                    break;
                case "circle":
                    break;
            }
        }

        Point pointSnapping(System.Drawing.Point p)
        {
            foreach (Object O in parent.ObjectsInSketch)
            {
                if (O.GetType() == typeof(Point))
                {
                    if (isInDistancePoints((O as Point).systemPoint, p, 10 / parent.Scale))
                        return O as Point;
                }
            }
            return null;
        }

        bool isInDistancePoints(System.Drawing.Point pointA, System.Drawing.Point pointB, double maxDistance)
        {
            return ((pointA.X - pointB.X) * (pointA.X - pointB.X) + (pointA.Y - pointB.Y) * (pointA.Y - pointB.Y)) < maxDistance * maxDistance;
        }

    }


}
