using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ClassLibDraw
{
    public class ComplexShape : IDrawable
    {
        public Point TopLeft { get; set; }
        public List<IDrawable> ShapeList { get; set; }
        public int Number { get; set; }

        public ComplexShape()
        {
            TopLeft = new Point();
            ShapeList = new List<IDrawable>();
            Random random = new Random();
            Number = random.Next(0, 100);
        }

        public ComplexShape(int inNumb)
        {
            TopLeft = new Point();
            ShapeList = new List<IDrawable>();
            Random random = new Random();
            Number = random.Next(0, 100);
        }

        public ComplexShape(Point inPoint, List<IDrawable> inList)
        {
            TopLeft = inPoint;
            ShapeList = inList;
            Random random = new Random();
            Number = random.Next(0, 100);
        }

        public void Draw(Graphics graph)
        {
            Point temp = new Point();
            Point save;
            foreach (var item in ShapeList)
            {
                save = item.TopLeft;
                if (item.TopLeft.X < TopLeft.X && item.TopLeft.Y < TopLeft.Y) // ne pas augmenter de Top left mais de item - topleft
                {
                    temp.X = item.TopLeft.X + TopLeft.X;
                    temp.Y = item.TopLeft.Y + TopLeft.Y;
                    item.TopLeft = temp;
                }
                else if (item.TopLeft.X > TopLeft.X && item.TopLeft.Y > TopLeft.Y)
                {
                    temp.X = item.TopLeft.X - TopLeft.X;
                    temp.Y = item.TopLeft.Y - TopLeft.Y;
                    item.TopLeft = temp;
                }
                else if (item.TopLeft.X < TopLeft.X && item.TopLeft.Y > TopLeft.Y)
                {
                    temp.X = item.TopLeft.X + TopLeft.X;
                    temp.Y = item.TopLeft.Y - TopLeft.Y;
                    item.TopLeft = temp;
                }
                else if (item.TopLeft.X > TopLeft.X && item.TopLeft.Y < TopLeft.Y)
                {
                    temp.X = item.TopLeft.X - TopLeft.X;
                    temp.Y = item.TopLeft.Y + TopLeft.Y;
                    item.TopLeft = temp;
                }
                item.Draw(graph);
                item.TopLeft = save;
            }
        }

        public override string ToString()
        {
            return "ComplexShape " + Number;
        }
    }
}
