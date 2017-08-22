using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnergyLib
{
    public enum Profil {Administrateur, Proprietaire, Unknown};

    public class User : IEquatable<User>
    {
        public String Nom { get; set; }
        public String Passwd { get; set; }
        public Profil Auth { get; set; }

        public User()
        {
            Nom = "Def";
            Passwd = "Def";
            Auth = Profil.Unknown;
        }
        public User(string nom, string passwd, Profil auth)
        {
            Nom = nom;
            Passwd = passwd;
            Auth = auth;
        }

        public bool Equals(User other)
        {
            if (other == null)
                return false;

            if (Nom == other.Nom && Passwd == other.Passwd)
                return true;
            else
                return false;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            User A = obj as User;
            if (A == null)
                return false;
            else
                return Equals(obj);
        }

        public static bool operator ==(User A, User B)
        {
            if (object.ReferenceEquals(A, B)) return true;
            if (object.ReferenceEquals(A, null)) return false;
            if (object.ReferenceEquals(B, null)) return false;

            return A.Equals(B);
        }

        public static bool operator !=(User A, User B)
        {
            if (object.ReferenceEquals(A, B)) return false;
            if (object.ReferenceEquals(A, null)) return true;
            if (object.ReferenceEquals(B, null)) return true;

            return !A.Equals(B);
        }

        public override string ToString()
        {
            return Nom + "@" + Passwd;
        }

        public override int GetHashCode()
        {
            return Nom.GetHashCode();
        }
    }
}
