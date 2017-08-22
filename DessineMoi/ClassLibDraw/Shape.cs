using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ClassLibDraw
{
    public abstract class Shape : IDrawable
    {
        public Point TopLeft { get; set; }
        public bool Filled { get; set; }
        public Color Couleur { get; set; }

        public Shape()
        {
            TopLeft = new Point();
            Filled = false;
            Couleur = Color.Black;
        }

        public Shape(Point inPoint, bool inFilled, Color inColor)
        {
            TopLeft = inPoint;
            Filled = inFilled;
            Couleur = inColor;
        }

        public virtual void Draw(Graphics graph)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            if (Filled)
            {
                return TopLeft.ToString() + " Filled " + Couleur.ToString();
            }
            else
            {
                return TopLeft.ToString() + " NotFilled " + Couleur.ToString();
            }
        }
    }
}
