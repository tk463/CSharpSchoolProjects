using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ClassLibDraw
{
    public class Square : Shape
    {
        public int Cote { get; set; }

        public Square() : base()
        {
            Cote = 0;
        }

        public Square(Point inPoint, bool inFilled, Color inColor, int inCote) : base(inPoint, inFilled, inColor)
        {
            Cote = inCote;
        }

        public override void Draw(Graphics graph)
        {
            SolidBrush brush = new SolidBrush(Couleur);
            Pen pen = new Pen(brush, 1);
            if (Filled)
            {
                graph.FillRectangle(brush, TopLeft.X, TopLeft.Y, Cote, Cote);
            }
            else
            {
                graph.DrawRectangle(pen, TopLeft.X, TopLeft.Y, Cote, Cote);
            }
        }

        public override string ToString()
        {
            return "Square " + base.ToString();
        }
    }
}
