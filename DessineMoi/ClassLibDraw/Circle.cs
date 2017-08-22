using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ClassLibDraw
{
    public class Circle : Shape
    {
        public int Cote { get; set; }

        public Circle() : base()
        {
            Cote = 0;
        }

        public Circle(Point inPoint, bool inFilled, Color inColor, int inCote) : base(inPoint, inFilled, inColor)
        {
            Cote = inCote;
        }

        public override void Draw(Graphics graph)
        {
            SolidBrush brush = new SolidBrush(Couleur);
            Pen pen = new Pen(brush, 1);
            if (Filled)
            {
                graph.FillEllipse(brush, TopLeft.X, TopLeft.Y, Cote, Cote);
            }
            else
            {
                graph.DrawEllipse(pen, TopLeft.X, TopLeft.Y, Cote, Cote);
            }
        }

        public override string ToString()
        {
            return "Circle " + base.ToString();
        }
    }
}
