using System.Drawing;


namespace Invertor
{
    public abstract class Object
    {
        string name;
        bool locked;

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public bool Locked
        {
            get
            {
                return locked;
            }

            set
            {
                locked = value;
            }
        }

        abstract public void Render(Graphics g, Bitmap b,Point origin, double scale);

        abstract public void highlight(Graphics g, Bitmap b, Point origin, double scale, Color c);

        abstract public void resolveTies();

        abstract public string toJson();
    }
}
