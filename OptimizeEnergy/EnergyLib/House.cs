using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace EnergyLib
{
    public class House
    {
        public string Nom { get; set; }
        public int ID { get; set; }
        public string Adresse { get; set; }
        public BindingList<Floor> floorList { get; set; }
        public string PicName { get; set; }

        public House()
        {
            floorList = new BindingList<Floor>();
            Adresse = "Def";
        }
        public House(BindingList<Floor> levels)
        {
            floorList = levels;
            Adresse = "Def";
        }
        public House(int id)
        {
            floorList = new BindingList<Floor>();
            ID = id;
            Adresse = "Def";
        }

        public override string ToString()
        {
            return "House " + ID;
        }
    }
}
