using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Invertor
{
    class Line : Object
    {
        private Point startPoint,endPoint;
        private double width;
        Color color = Color.White; 

        public Line(string Name, Point StartPoint,Point EndPoint,double Width)
        {
            this.Name = Name;
            startPoint = StartPoint;
            endPoint = EndPoint;
            width = Width;
        }

        #region getters and setters

        public Point StartPoint
        {
            get
            {
                return startPoint;
            }

            set
            {
                startPoint = value;
            }
        }

        public Point EndPoint
        {
            get
            {
                return endPoint;
            }

            set
            {
                endPoint = value;
            }
        }

        public Color Color
        {
            get
            {
                return color;
            }

            set
            {
                color = value;
            }
        }

        #endregion

        public override void Render(Graphics g,Bitmap b, Point origin)
        {
            g.DrawLine(new Pen(Color, 1), new System.Drawing.Point(startPoint.X + origin.X, startPoint.Y + origin.Y), new System.Drawing.Point(endPoint.X + origin.X, endPoint.Y + origin.Y));
            
        }

        public override string ToString()
        {
            return Name + StartPoint.ToString() + endPoint.ToString();
        }

    }
}
