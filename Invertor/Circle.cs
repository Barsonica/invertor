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
            center = Center;
            diameter = Diameter;
            color = Color;
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

        public double Diameter { get => diameter; set => diameter = value; }
        public Color Color { get => color; set => color = value; }
        internal Point Center { get => center; set => center = value; }

        public override void Render(Graphics g, Bitmap b, Point origin, double scale)
        {
            g.DrawEllipse(new Pen(Color), new Rectangle(new System.Drawing.Point((int)(scale * (center.X - Diameter)) + origin.X, (int)(scale * (center.Y - Diameter)) + origin.Y),new Size((int)(Diameter+Diameter), (int)(Diameter+Diameter))));

        }

        public override string toJson()
        {
            string result = "";
            result += "Name:" + Name + ",";
            result += "Center:" + Center + ",";
            result += "Radius:" + Diameter + ",";
            result += "Color:" + Color + ",";

            return result;
        }

        public override string ToString()
        {
            return Name + ": " + center.Name + ": " + (int)Diameter;
        }

    }
}
