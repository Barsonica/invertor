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
        private int width;
        Color color = Color.White;

        public Line() { }//needed for saving

        public Line(string Name, Point StartPoint,Point EndPoint,int Width)
        {
            this.Name = Name;
            startPoint = StartPoint;
            endPoint = EndPoint;
            this.Width = Width;
        }

        public Line(string Name, Point StartPoint, Point EndPoint, int Width, Color c)
        {
            this.Name = Name;
            startPoint = StartPoint;
            endPoint = EndPoint;
            this.Width = Width;
            color = c;
        }

        public Line(string file)
        {
            string[] parameters = file.Split(',');
            for (int i = 0; i < parameters.Length - 1; i++)
            {
                string[] values = parameters[i].Split(':');
                switch (values[0])
                {
                    case "Name":
                        Name = values[1];
                        break;
                    case "Width":
                        Width = int.Parse(values[1]);
                        break;
                    case "Color":
                        Color = Color.FromArgb(int.Parse(values[1]));
                        break;
                    case "startPoint":
                        startPoint = new Point(values[1].Trim(),0,0);
                        break;
                    case "endPoint":
                        endPoint = new Point(values[1].Trim(), 0, 0);
                        break;
                }
            }
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

        public int Width
        {
            get
            {
                return width;
            }

            set
            {
                width = value;
            }
        }

        #endregion

        public override void Render(Graphics g,Bitmap b, Point origin, double scale)
        {
            //if(inBitmap(b, origin, scale))
            g.DrawLine(new Pen(Color, Width), new System.Drawing.Point((int)(scale * startPoint.X) + origin.X, (int)(scale * startPoint.Y) + origin.Y), new System.Drawing.Point((int)(endPoint.X * scale) + origin.X, (int)(endPoint.Y * scale) + origin.Y));
            
        }

        bool inBitmap(Bitmap bmp, Point origin, double scale)
        {
            bool result = (scale * startPoint.X) + origin.X < bmp.Width && (scale * startPoint.X) + origin.X > 0;
            result &= (scale * startPoint.Y) + origin.Y < bmp.Height && (scale * startPoint.Y) + origin.Y > 0;
            result &= (scale * endPoint.X) + origin.X < bmp.Width && (scale * endPoint.X) + origin.X > 0;
            result &= (scale * endPoint.Y) + origin.Y < bmp.Height && (scale * endPoint.Y) + origin.Y > 0;
            return result;
        }

        public override string ToString()
        {
            return Name + " - " + StartPoint.Name + " - " + endPoint.Name;
        }

        public override string toJson()
        {
            string result = "";
            result += "Name:" + Name + ",";
            result += "startPoint:" +startPoint.Name + ",";
            result += "endPoint:" + endPoint.Name + ",";
            result += "Width:" + Width.ToString() + ",";
            result += "Color:" + color.ToArgb() + ",";

            return result;
        }

    }
}
