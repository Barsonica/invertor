using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invertor
{
    class Label : Object
    {
        private string text;

        public override void Render(Graphics g, Bitmap b, Point origin, double scale)
        {
            throw new NotImplementedException();
        }

        public override void highlight(Graphics g, Bitmap b, Point origin, double scale, Color c)
        {
            throw new NotImplementedException();
        }

        public override void resolveTies()
        {

        }

        public override string toJson()
        {
            return "";
        }

    }
}
