using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace EnergyLib
{
    public enum TypeAppareil {Electromenager, Media, Chauffage, Eclairage, Autre};

    public class Appareil : IFormattable, IEquatable<Appareil>, IComparable<Appareil>
    {
        #region PROPERTIES
        public String Marque { get; set; }
        public String Modele { get; set; }
        public String NumeroSerie { get; set; }
        public double Consommation { get; set; }
        public DateTime DateMiseEnService { get; set; }
        public TimeSpan? DureeUtilisationMoyenne { get; set; }
        public TypeAppareil Type { get; set; }
        public Autorisation Autorisation { get; set; }
        public Rectangle Surface { get; set; }

        public static int CPT = 0;
        #endregion

        #region CONSTRUCTEURS
        public Appareil()
        {
            setSurface(0, 0);
            Marque = "Def";
            Modele = "Def";
            NumeroSerie = "Def";
            Consommation = 0;
            DateMiseEnService = DateTime.Now;
            CPT++;
            Autorisation = new Autorisation();
        }

        public Appareil(string Mod, string NumSer)
        {
            setSurface(0, 0);
            Marque = "Def";
            Modele = Mod;
            NumeroSerie = NumSer;
            Consommation = 0;
            DateMiseEnService = DateTime.Now;
            CPT++;
            Autorisation = new Autorisation();
        }

        public Appareil(string Marq, string Mod, string NumSer, double Conso, TypeAppareil type)
        {
            setSurface(0, 0);
            Marque = Marq;
            Modele = Mod;
            NumeroSerie = NumSer;
            Consommation = Conso;
            DateMiseEnService = DateTime.Now;
            Type = type;
            CPT++;
            Autorisation = new Autorisation();
        }
        #endregion

        #region DESTRUCTEUR
        ~Appareil()
        {
            CPT--;
        }
        #endregion

        #region AFFICHAGE
        public string ToString(string format, IFormatProvider formatProvider)
        {
            if (String.IsNullOrEmpty(format)) format = "Resume";

            switch(format)
            {
                case "Resume":
                    return Marque + " " + Modele + " " + NumeroSerie;
                case "Detail":
                    return Marque + " " + Modele + " " + NumeroSerie + " " + " " + Consommation + " " + DateMiseEnService + " " + DureeUtilisationMoyenne;
                default:
                    return null;
            }
        }

        public string Key
        {
            get
            {
                return (Marque + Modele + NumeroSerie);
            }
        }
        #endregion

        #region OPERATORS
        public static bool operator== (Appareil A, Appareil B)
        {
            if (object.ReferenceEquals(A, B)) return true;
            if (object.ReferenceEquals(A, null)) return false;
            if (object.ReferenceEquals(B, null)) return false;

            return A.Equals(B);
        }

        public static bool operator!= (Appareil A, Appareil B)
        {
            if (object.ReferenceEquals(A, B)) return false;
            if (object.ReferenceEquals(A, null)) return true;
            if (object.ReferenceEquals(B, null)) return true;

            return !A.Equals(B);
        }

        public static string operator+ (string A, Appareil B)
        {
            return B.ToString("Resume", null);
        }
        #endregion

        #region INTERFACES + COMPARISONS
        public bool Equals(Appareil other)
        {
            if (other == null)
                return false;

            if (NumeroSerie == other.NumeroSerie)
                return true;
            else
                return false;
        }

        public int CompareTo(Appareil other)
        {
            return NumeroSerie.CompareTo(other.NumeroSerie);
        }

        public static int ComparisonMiseEnService(Appareil A, Appareil B)
        {
            return A.DateMiseEnService.CompareTo(B.DateMiseEnService);
        }

        public static int ComparisonMiseEnServiceDecroisant(Appareil A, Appareil B)
        {
            return -(A.DateMiseEnService.CompareTo(B.DateMiseEnService));
        }
        #endregion

        #region OBJECT OVERRIDES
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            Appareil A = obj as Appareil;
            if (A == null)
                return false;
            else
                return Equals(obj);
        }

        public override int GetHashCode()
        {
            return this.NumeroSerie.GetHashCode();
        }

        public override string ToString()
        {
            return this.ToString("Resume", null);
        }
        #endregion

        public void setSurface (int x, int y)
        {
            Surface = new Rectangle(x, y, 50, 50);
        }
    }
}
