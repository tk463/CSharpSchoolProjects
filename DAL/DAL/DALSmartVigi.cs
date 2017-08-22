using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DALSmartVigi
    {
        private DataClassesSmartVigiDataContext DataContext;

        public void Init()
        {
            DataContext = new DataClassesSmartVigiDataContext();
        }

        public void Commit()
        {
            DataContext.SubmitChanges();
            DataContext.Dispose();
            Init();
        }

        public List<Utilisateurs> SelectAllUtilisateurs()
        {
            if (DataContext == null)
                throw new Exception("DAL empty");

            return DataContext.Utilisateurs.ToList();
        }

        public List<Repertoire> SelectAllRepertoire(int IDUtilisateur)
        {
            if (DataContext == null)
                throw new Exception("DAL empty");

            var utilisateur = DataContext.Utilisateurs.Where(u => u.ID == IDUtilisateur).SingleOrDefault();

            if (utilisateur == null)
                return new List<Repertoire>();

            return utilisateur.Repertoire.ToList();
        }

        public List<Interventions> SelectAllInterventions(int IDUtilisateur)
        {
            if (DataContext == null)
                throw new Exception("DAL empty");

            List<Repertoire> repList = SelectAllRepertoire(IDUtilisateur);
            List<Interventions> intervList = new List<Interventions>();

            foreach (var item in repList)
            {
                intervList.AddRange(item.Interventions.ToList());
            }

            return intervList;
        }

        public List<Interventions> SelectAllInterventions()
        {
            if (DataContext == null)
                throw new Exception("DAL empty");

            return DataContext.Interventions.ToList();
        }

        public bool InsertUtilisateur(Utilisateurs u)
        {
            try
            {
                if (DataContext == null)
                    throw new Exception("DAL empty");

                DataContext.Utilisateurs.InsertOnSubmit(u);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool InsertRepertoire(Repertoire r)
        {
            try
            {
                if (DataContext == null)
                    throw new Exception("DAL empty");

                DataContext.Repertoire.InsertOnSubmit(r);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool InsertIntervention(Interventions i)
        {
            try
            {
                if (DataContext == null)
                    throw new Exception("DAL empty");

                DataContext.Interventions.InsertOnSubmit(i);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool UpdateUtilisateur(Utilisateurs u)
        {
            try
            {
                Utilisateurs user = DataContext.Utilisateurs.Where(p => p.ID == u.ID).SingleOrDefault();

                if (user.Adresse != u.Adresse)
                    user.Adresse = u.Adresse;
                if (user.Email != u.Email)
                    user.Email = u.Email;
                if (user.Login != u.Login)
                    user.Login = u.Login;
                if (user.Nom != u.Nom)
                    user.Nom = u.Nom;
                if (user.NTel != u.NTel)
                    user.NTel = u.NTel;
                if (user.Password != u.Password)
                    user.Password = u.Password;
                if (user.Photo != u.Photo)
                    user.Photo = u.Photo;
                if (user.Prenom != u.Prenom)
                    user.Prenom = u.Prenom;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool UpdateRepertoire(Repertoire r)
        {
            try
            {
                Repertoire rep = DataContext.Repertoire.Where(p => p.IDUtilisateur == r.IDUtilisateur && p.IDContact == r.IDContact).SingleOrDefault();

                if (rep.Adresse != r.Adresse)
                    rep.Adresse = r.Adresse;
                if (rep.Email != r.Email)
                    rep.Email = r.Email;
                if (rep.Nom != r.Nom)
                    rep.Nom = r.Nom;
                if (rep.NTel != r.NTel)
                    rep.NTel = r.NTel;
                if (rep.Photo != r.Photo)
                    rep.Photo = r.Photo;
                if (rep.Prenom != r.Prenom)
                    rep.Prenom = r.Prenom;
                if (rep.Priorite != r.Priorite)
                    rep.Priorite = r.Priorite;

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool UpdateIntervention(Interventions i)
        {
            try
            {
                Interventions interv = DataContext.Interventions.Where(p => p.IDContact == i.IDContact && p.IDUtilisateur == i.IDUtilisateur && p.DateHeure == i.DateHeure).SingleOrDefault();

                if (interv.Data != i.Data)
                    interv.Data = i.Data;
                if (interv.GPSLocation != i.GPSLocation)
                    interv.GPSLocation = i.GPSLocation;
                if (interv.UrgenceLevel != i.UrgenceLevel)
                    interv.UrgenceLevel = i.UrgenceLevel;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool RemoveUtilisateur(Utilisateurs u)
        {
            try
            {
                if (DataContext == null)
                    throw new Exception("DAL empty");

                DataContext.Utilisateurs.DeleteOnSubmit(u);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool RemoveRepertoire(Repertoire r)
        {
            try
            {
                if (DataContext == null)
                    throw new Exception("DAL empty");

                DataContext.Repertoire.DeleteOnSubmit(r);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool RemoveIntervention(Interventions i)
        {
            try
            {
                if (DataContext == null)
                    throw new Exception("DAL empty");

                DataContext.Interventions.DeleteOnSubmit(i);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public int ObtainMaxIDUser()
        {
            Utilisateurs maxObject = DataContext.Utilisateurs.OrderByDescending(p => p.ID).First();
            return maxObject.ID;
        }

        public Utilisateurs SelectUtilisateur(string login, string password)
        {
            if (DataContext == null)
                throw new Exception("DAL empty");

            try
            {
                return DataContext.Utilisateurs.Single(c => c.Login == login && c.Password == password);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
