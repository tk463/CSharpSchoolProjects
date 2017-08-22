using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ClassLibDraw
{
    public interface IDrawable
    {
        Point TopLeft { get; set; }

        void Draw(Graphics graph);
    }
}
