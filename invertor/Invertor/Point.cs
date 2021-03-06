﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Invertor
{
    class Point : Object
    {
        int x, y, size;
        Color color = Color.White;
        

        public Point(string Name, int X,int Y)
        {
            this.Name = Name;
            x = X;
            y = Y;
        }

        public Point(string Name, int X, int Y, int Size)
        {
            this.Name = Name;
            x = X;
            y = Y;
            size = Size;
        }

        public Point(string Name, System.Drawing.Point p)
        {
            this.Name = Name;
            x = p.X;
            y = p.Y;
        }

        public Point(string file)
        {
            string[] parameters = file.Split(',');
            for(int i = 0; i < parameters.Length - 1; i++)
            {
                string[] values = parameters[i].Split(':');
                switch (values[0])
                {
                    case "Name":
                        Name = values[1];
                        break;
                    case "X":
                        X = int.Parse(values[1]);
                        break;
                    case "Y":
                        Y = int.Parse(values[1]);
                        break;
                    case "Size":
                        Size = int.Parse(values[1]);
                        break;
                    case "Color":
                        Color = Color.FromArgb(int.Parse(values[1]));
                        break;
                }
            }

            /*string[] splitted = file.Split(' ');
            Name = splitted[0];
            X = int.Parse(splitted[2]);
            Y = int.Parse(splitted[5]);*/
        }

        #region getters and setters

        public int X
        {
            get
            {
                return x;
            }

            set
            {
                x = value;
            }
        }

        public int Y
        {
            get
            {
                return y;
            }

            set
            {
                y = value;
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

        public System.Drawing.Point systemPoint
        {
            get
            {
                return new System.Drawing.Point(x,y);
            }

            set
            {
                x = value.X;
                y = value.Y;
            }
        }

        public int Size
        {
            get
            {
                return size;
            }

            set
            {
                size = value;
            }
        }

        #endregion

        public override void Render(Graphics g, Bitmap b, Point origin, double scale)
        {
            if (Name != "Origin")
                g.DrawRectangle(new Pen(Color, size), new Rectangle(new System.Drawing.Point((int)(scale * X) + origin.x, (int)(scale * Y) + origin.Y), new Size(1, 1)));
            else
                g.DrawRectangle(new Pen(Color, size), new Rectangle(new System.Drawing.Point(X, Y), new Size(1, 1)));
        }

        public override string ToString()
        {
            return Name + " X: " + X + " , Y: " + Y;
        }

        public override string toJson()
        {
            string result = "";
            result += "Name:" + Name + ",";
            result += "X:" + X.ToString() + ",";
            result += "Y:" + Y.ToString() + ",";
            result += "Size:" + Size.ToString() + ",";
            result += "Color:" + color.ToArgb() + ",";

            return result;
        }

    }
}
