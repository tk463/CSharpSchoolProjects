using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JeuxTestsApplic
{
    class MyAppareilComparer : IComparer<Appareil>
    {
        public int Compare(Appareil x, Appareil y)
        {
            return x.Consommation.CompareTo(y.Consommation);
        }
    }
}
