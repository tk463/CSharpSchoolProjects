using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ClassLibDraw
{
    public class Rect : Shape
    {
        public int Longeur { get; set; }
        public int Largeur { get; set; }

        public Rect() : base()
        {
            Longeur = 0;
            Largeur = 0;
        }

        public Rect(Point inPoint, bool inFilled, Color inColor, int inLong, int inLarg) : base(inPoint, inFilled, inColor)
        {
            Longeur = inLong;
            Largeur = inLarg;
        }

        public override void Draw(Graphics graph)
        {
            SolidBrush brush = new SolidBrush(Couleur);
            Pen pen = new Pen(brush, 1);
            if (Filled)
            {
                graph.FillRectangle(brush, TopLeft.X, TopLeft.Y, Longeur, Largeur);
            }
            else
            {
                graph.DrawRectangle(pen, TopLeft.X, TopLeft.Y, Longeur, Largeur);
            }
        }

        public override string ToString()
        {
            return "Rect " + base.ToString();
        }
    }
}
