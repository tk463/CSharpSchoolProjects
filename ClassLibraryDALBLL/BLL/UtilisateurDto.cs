﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class UtilisateurDto
    {
        public int ID { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Adresse { get; set; }
        public string NTel { get; set; }
        public string Email { get; set; }
        public Image Photo { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
