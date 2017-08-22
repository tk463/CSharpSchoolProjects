using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ClassLibDraw
{
    public class MyImage : IDrawable
    {
        public Point TopLeft { get; set; }
        public string File { get; set; }

        public MyImage()
        {
            TopLeft = new Point();
        }

        public MyImage(Point inPoint, string inFile)
        {
            TopLeft = inPoint;
            File = inFile;
        }

        public void Draw(Graphics graph)
        {
            Bitmap bitmap = new Bitmap(File);
            graph.DrawImage(bitmap, TopLeft);
        }

        public override string ToString()
        {
            return "MyImage " + TopLeft.ToString() + " " + File;
        }
    }
}
