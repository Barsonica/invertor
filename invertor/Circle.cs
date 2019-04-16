using System;
using System.Drawing;

namespace Invertor
{
    public class Circle : Object
    {

        private Point center;
        private double diameter;
        private Color color;
        
        public Circle(string name, Point Center, double Diameter, Color Color)
        {
            Name = name;
            this.Center = Center;
            this.Diameter = Diameter;
            this.Color = Color;
        }

        public Circle(string json)
        {
            string[] parameters = json.Split(',');
            for (int i = 0; i < parameters.Length - 1; i++)
            {
                string[] values = parameters[i].Split(':');
                switch (values[0])
                {
                    case "Name":
                        Name = values[1];
                        break;
                    case "Center":
                        Center = new Point(values[1].Trim(), 0, 0);
                        break;
                    case "Diameter":
                        Diameter = int.Parse(values[1]);
                        break;
                    case "Color":
                        Color = Color.FromArgb(int.Parse(values[1]));
                        break;
                }
            }
        }

        #region getters and setters

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

        public double Diameter
        {
            get
            {
                return diameter;
            }

            set
            {
                diameter = value;
            }
        }

        public Point Center
        {
            get
            {
                return center;
            }

            set
            {
                center = value;
            }
        }

        #endregion

        public override void Render(Graphics g, Bitmap b, Point origin, double scale)
        {
            Point renderPoint = new Point("", (int)(scale * (Center.X - Diameter)) + origin.X, (int)(scale * (Center.Y - Diameter)) + origin.Y);
            Rectangle renderRect = new Rectangle(renderPoint.systemPoint,new Size((int)((Diameter + Diameter)*scale), (int)((Diameter + Diameter)*scale)));
            g.DrawEllipse(new Pen(Color), renderRect);

        }

        public override string toJson()
        {
            string result = "";
            result += "Name:" + Name + ",";
            result += "Center:" + Center.Name + ",";
            result += "Diameter:" + Diameter.ToString() + ",";
            result += "Color:" + Color.ToArgb() + ",";

            return result;
        }

        public override string ToString()
        {
            return Name + ": " + Center.Name + ": " + (int)Diameter;
        }

    }
}
