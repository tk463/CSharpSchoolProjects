using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WcfServiceSmartVigi
{
    public class RepertoirePhone
    {
        public int IDUtilisateur { get; set; }
        public int IDContact { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Adresse { get; set; }
        public string NTel { get; set; }
        public string Email { get; set; }
        public int Priorite { get; set; }
    }
}