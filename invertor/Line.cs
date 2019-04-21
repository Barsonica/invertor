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
        private Point startPoint, endPoint;
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
                    case "StartPoint":
                        startPoint = new Point(values[1].Trim(), 0, 0);
                        break;
                    case "EndPoint":
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

        public List<Line> ParaelLines { get => paraelLines; set => paraelLines = value; }
        public List<Line> PerpLines { get => perpLines; set => perpLines = value; }

        #endregion

        public override void Render(Graphics g, Bitmap b, Point origin, double scale)
        {
            //if(inBitmap(b, origin, scale))
            g.DrawLine(new Pen(Color, Width), new System.Drawing.Point((int)(scale * startPoint.X) + origin.X, (int)(scale * startPoint.Y) + origin.Y), new System.Drawing.Point((int)(endPoint.X * scale) + origin.X, (int)(endPoint.Y * scale) + origin.Y));
        }

        public override void resolveTies()
        {
            foreach (Line l in paraelLines)
            {
                l.setDirection(Direction());
            }
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


        public direction Direction()
        {
            direction result = new direction();

            double diffX = EndPoint.X - StartPoint.X;
            double diffY = EndPoint.Y - StartPoint.Y;

            if (Math.Abs(diffX) > Math.Abs(diffY))
            {
                result.Y = diffY / Math.Abs(diffX); // something absolute lower than 1
                result.X = diffX / Math.Abs(diffX); // 1 or -1
            }
            else if (Math.Abs(diffX) < Math.Abs(diffY))
            {
                result.X = diffX / Math.Abs(diffY); // something absolute lower than 1
                result.Y = diffY / Math.Abs(diffY); // 1 or -1
            }
            else
            {
                result.X = diffX / Math.Abs(diffX);
                result.Y = diffY / Math.Abs(diffY);
            }

            return result;
        }

        public double Degrees()
        {
            direction D = Direction();

            if (Math.Abs(D.X) > Math.Abs(D.Y))
            {
                if (D.X < 0)
                {
                    D.X -= 1;
                    D.Y = Math.Abs(D.Y) / 2;
                    return ((D.Y * 90) + 90);
                }
                else
                {
                    D.Y -= 1;
                    D.Y = Math.Abs(D.Y) / 2;
                    return ((D.Y * 90) + 270);
                }

            }
            else if (Math.Abs(D.X) < Math.Abs(D.Y))
            {

                if (D.Y < 0)
                {
                    D.X -= 1;
                    D.X = Math.Abs(D.X) / 2;
                    return ((D.X * 90) + 180);
                }
                else
                {
                    D.X -= 1;
                    D.X = Math.Abs(D.X) / 2;
                    return ((D.X * 90));
                }
            }
            else //they are equal
            {
                if (D.X > 0)
                {
                    if (D.Y > 0)
                        return 0;
                    else
                        return 270;
                }
                else
                {
                    if (D.Y > 0)
                        return 90;
                    else
                        return 180;
                }
            }
            throw new Exception("invalid parameter");
        }

        public void setDirection(direction D)
        {

            double lenght = StartPoint.distance(EndPoint);

            double ratio = lenght / (D.X + D.Y);

            EndPoint.X = StartPoint.X + (int)(ratio * D.X);
            EndPoint.Y = StartPoint.Y + (int)(ratio * D.Y);
        }

    }

    public struct direction
    {
        double x, y;

        public double X { get => x; set => x = value; }
        public double Y { get => y; set => y = value; }

        public override string ToString()
        {
            return X + " " + Y;
        }
    }

}
