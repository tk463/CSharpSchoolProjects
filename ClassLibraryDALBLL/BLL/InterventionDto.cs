using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class InterventionDto
    {
        public int IDUtilisateur { get; set; }
        public int IDContact { get; set; }
        public DateTime DateHeure { get; set; }
        public int UrgenceLevel { get; set; }
        public string GPSLocation { get; set; }
        public string Data { get; set; }
    }
}
