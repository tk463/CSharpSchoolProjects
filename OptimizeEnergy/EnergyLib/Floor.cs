using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace EnergyLib
{
    public class Floor
    {
        public string Nom { get; set; }
        public BindingList<Room> roomList { get; set; }

        public Floor()
        {
            roomList = new BindingList<Room>();
        }
    }
}
