using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Drawing;

namespace EnergyLib
{
    public class Room
    {
        public string Nom { get; set; }
        public BindingList<Appareil> listeAppareils { get; set; }
        public Rectangle surface { get; set; }

        public void setSurface(Point surfacee)
        {
            surface = new Rectangle(surfacee.X, surfacee.Y, surface.Width, surface.Height);
        }
        public void resize(int newWidth, int newHeight)
        {
            surface = new Rectangle(surface.X, surface.Y, newWidth, newHeight);
        }
        public Room()
        {
            listeAppareils = new BindingList<Appareil>();
            surface = new Rectangle(0, 0, 100, 100);
        }
    }
}
