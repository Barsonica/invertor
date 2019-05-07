using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Numerics;


namespace Invertor
{
    public class Line : Object
    {
        private Point startPoint, endPoint, midPoint;
        private int width;
        Color color = Color.White;

        private List<Line> paraelLines = new List<Line>();
        private List<Line> perpLines = new List<Line>();

        public Line() { }//needed for saving

        public Line(string Name, Point StartPoint, Point EndPoint, int Width)
        {
            this.Name = Name;
            startPoint = StartPoint;
            endPoint = EndPoint;
            this.Width = Width;

            midPoint = new Point((int)((StartPoint.X + EndPoint.X) / 2), (int)((StartPoint.X + EndPoint.Y) / 2));
        }

        public Line(string Name, Point StartPoint, Point EndPoint, int Width, Color c)
        {
            this.Name = Name;
            startPoint = StartPoint;
            endPoint = EndPoint;
            this.Width = Width;
            color = c;
            midPoint = new Point((int)((StartPoint.X + EndPoint.X) / 2), (int)((StartPoint.X + EndPoint.Y) / 2));
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
                    case "StartPoint":
                        startPoint = new Point(values[1].Trim(), 0, 0);
                        break;
                    case "EndPoint":
                        endPoint = new Point(values[1].Trim(), 0, 0);
                        break;
                }
            }
            midPoint = new Point((int)((StartPoint.X + EndPoint.X) / 2), (int)((StartPoint.X + EndPoint.Y) / 2));
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
                if (!Locked)
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
                if (!Locked)
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

        public List<Line> ParaelLines
        {
            get
            {
                return paraelLines;
            }

            set
            {
                paraelLines = value;
            }
        }

        public List<Line> PerpLines
        {
            get
            {
                return perpLines;
            }

            set
            {
                perpLines = value;
            }
        }

        public double Lenght
        {
            get
            {
                return StartPoint.distance(EndPoint);
            }
        }


        #endregion

        public override void Render(Graphics g, Bitmap b, Point origin, double scale)
        {
            g.DrawLine(new Pen(Color, Width), new System.Drawing.Point((int)(scale * startPoint.X) + origin.X, (int)(scale * startPoint.Y) + origin.Y), new System.Drawing.Point((int)(endPoint.X * scale) + origin.X, (int)(endPoint.Y * scale) + origin.Y));
        }

        public override void highlight(Graphics g, Bitmap b, Point origin, double scale, Color c)
        {
            g.DrawLine(new Pen(c, Width*3), new System.Drawing.Point((int)(scale * startPoint.X) + origin.X, (int)(scale * startPoint.Y) + origin.Y), new System.Drawing.Point((int)(endPoint.X * scale) + origin.X, (int)(endPoint.Y * scale) + origin.Y));
        }

        public override void resolveTies()
        {
            foreach (Line l in paraelLines)
            {
                l.setDirection(slope(),this);
            }

            midPoint = new Point((int)((StartPoint.X + EndPoint.X) / 2), (int)((StartPoint.X + EndPoint.Y) / 2));
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
            return Name + ": " + StartPoint.Name + " - " + endPoint.Name;
        }

        public override string toJson()
        {
            string result = "";
            result += "Name:" + Name + ",";
            result += "StartPoint:" + startPoint.Name + ",";
            result += "EndPoint:" + endPoint.Name + ",";
            result += "Width:" + Width.ToString() + ",";
            result += "Color:" + color.ToArgb() + ",";

            return result;
        }

        double slope()
        {
            if ((startPoint.X - endPoint.X) == 0)
                return double.MaxValue;
            else if ((startPoint.Y - endPoint.Y) == 0)
                return 0;
            else
                return Math.Abs(startPoint.Y - endPoint.Y) / Math.Abs(startPoint.X - endPoint.X);
        }

        public void setDirection(double slope, Line sender)
        {
            System.Drawing.Point a = new System.Drawing.Point(), b = new System.Drawing.Point();

            if (slope == 0)
            {
                a.X = (int)(startPoint.X + Lenght);
                a.Y = startPoint.X;

                b.X = (int)(startPoint.X - Lenght);
                b.Y = startPoint.Y;
            }

            // if slope is infinte 
            else if (slope == double.MaxValue)
            {
                a.X = startPoint.X;
                a.Y = (int)(startPoint.Y + Lenght);

                b.X = startPoint.X;
                b.Y = (int)(startPoint.Y - Lenght);
            }
            else
            {
                double dx = (Lenght / Math.Sqrt(1 + (slope * slope)));
                double dy = slope * dx;
                a.X = (int)(startPoint.X + dx);
                a.Y = (int)(startPoint.Y + dy);
                b.X = (int)(startPoint.X - dx);
                b.Y = (int)(startPoint.Y - dy);
            }

            if (Math.Min(sender.StartPoint.distance(a), sender.StartPoint.distance(b)) < Math.Min(sender.EndPoint.distance(a), sender.EndPoint.distance(b)))
                if ( sender.StartPoint.distance(a) < sender.StartPoint.distance(b) )
                    endPoint.fromSystemPoint(a);
                else
                    endPoint.fromSystemPoint(b);
            else
                if (sender.EndPoint.distance(a) < sender.EndPoint.distance(b))
                    endPoint.fromSystemPoint(a);
                else
                    endPoint.fromSystemPoint(b);

            endPoint.X = a.X;
            endPoint.Y = b.X;

        }


    }

    }
    


