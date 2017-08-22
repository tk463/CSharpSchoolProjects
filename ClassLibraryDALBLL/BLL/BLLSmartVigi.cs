using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLLSmartVigi
    {
        private DALSmartVigi DataAcces;

        public void StartDAL()
        {
            DataAcces.Init();
        }

        public void CommitChanges()
        {
            DataAcces.Commit();
        }

        public BLLSmartVigi()
        {
            DataAcces = new DALSmartVigi();
        }

        public List<UtilisateurDto> SelectAllUtilisateurs()
        {
            return DataAcces.SelectAllUtilisateurs().Select(
                u => new UtilisateurDto
                {
                    ID = u.ID,
                    Nom = u.Nom,
                    Prenom = u.Prenom,
                    Adresse = u.Adresse,
                    NTel = u.NTel,
                    Email = u.Email,
                    Photo = BLLUtilities.BinaryToImg(u.Photo),
                    Login = u.Login,
                    Password = u.Password
                }
            ).ToList();
        }

        public List<RepertoireDto> SelectAllRepertoire(int IDUtilisateur)
        {
            return DataAcces.SelectAllRepertoire(IDUtilisateur).Select(
                r => new RepertoireDto
                {
                    IDUtilisateur = r.IDUtilisateur,
                    IDContact = r.IDContact,
                    Nom = r.Nom,
                    Prenom = r.Prenom,
                    Adresse = r.Adresse,
                    NTel = r.NTel,
                    Email = r.Email,
                    Photo = BLLUtilities.BinaryToImg(r.Photo),
                    Priorite = r.Priorite
                }
            ).ToList();
        }

        public List<InterventionDto> SelectAllInterventions()
        {
            return DataAcces.SelectAllInterventions().Select(
                i => new InterventionDto
                {
                    IDUtilisateur = i.IDUtilisateur,
                    IDContact = i.IDContact,
                    DateHeure = i.DateHeure,
                    UrgenceLevel = i.UrgenceLevel,
                    GPSLocation = i.GPSLocation,
                    Data = i.Data
                }
            ).ToList();
        }

        public List<InterventionDto> SelectAllInterventions(int IDUtilisateur)
        {
            return DataAcces.SelectAllInterventions(IDUtilisateur).Select(
                i => new InterventionDto
                {
                    IDUtilisateur = i.IDUtilisateur,
                    IDContact = i.IDContact,
                    DateHeure = i.DateHeure,
                    UrgenceLevel = i.UrgenceLevel,
                    GPSLocation = i.GPSLocation,
                    Data = i.Data
                }
            ).ToList();
        }

        public IEnumerable<InterventionDto> SelectAllInterventionsAsEnum(int IDUtilisateur)
        {
            return DataAcces.SelectAllInterventions(IDUtilisateur).Select(
                i => new InterventionDto
                {
                    IDUtilisateur = i.IDUtilisateur,
                    IDContact = i.IDContact,
                    DateHeure = i.DateHeure,
                    UrgenceLevel = i.UrgenceLevel,
                    GPSLocation = i.GPSLocation,
                    Data = i.Data
                }
            ).AsEnumerable<InterventionDto>();
        }

        private Utilisateurs UtilisateurFromDto(UtilisateurDto u)
        {
            return new Utilisateurs
            {
                ID = u.ID,
                Nom = u.Nom,
                Prenom = u.Prenom,
                Adresse = u.Adresse,
                NTel = u.NTel,
                Email = u.Email,
                Photo = BLLUtilities.ImgToBinary(u.Photo),
                Login = u.Login,
                Password = u.Password
            };
        }

        private Repertoire RepertoireFromDto(RepertoireDto r)
        {
            return new Repertoire
            {
                IDUtilisateur = r.IDUtilisateur,
                IDContact = r.IDContact,
                Nom = r.Nom,
                Prenom = r.Prenom,
                Adresse = r.Adresse,
                NTel = r.NTel,
                Email = r.Email,
                Photo = BLLUtilities.ImgToBinary(r.Photo),
                Priorite = r.Priorite
            };
        }

        private Interventions InterventionFromDto(InterventionDto i)
        {
            return new Interventions
            {
                IDUtilisateur = i.IDUtilisateur,
                IDContact = i.IDContact,
                DateHeure = i.DateHeure,
                UrgenceLevel = i.UrgenceLevel,
                GPSLocation = i.GPSLocation,
                Data = i.Data
            };
        }

        public bool InsertUtilisateur(UtilisateurDto u)
        {
            return DataAcces.InsertUtilisateur(UtilisateurFromDto(u));
        }

        public bool InsertRepertoire(RepertoireDto r)
        {
            return DataAcces.InsertRepertoire(RepertoireFromDto(r));
        }

        public bool InsertIntervention(InterventionDto i)
        {
            return DataAcces.InsertIntervention(InterventionFromDto(i));
        }

        public bool UpdateUtilisateur(UtilisateurDto u)
        {
            return DataAcces.UpdateUtilisateur(UtilisateurFromDto(u));
        }

        public bool UpdateRepertoire(RepertoireDto r)
        {
            return DataAcces.UpdateRepertoire(RepertoireFromDto(r));
        }

        public bool UpdateIntervention(InterventionDto i)
        {
            return DataAcces.UpdateIntervention(InterventionFromDto(i));
        }

        public bool RemoveUtilisateur(UtilisateurDto u)
        {
            return DataAcces.RemoveUtilisateur(UtilisateurFromDto(u));
        }

        public bool RemoveRepertoire(RepertoireDto r)
        {
            return DataAcces.RemoveRepertoire(RepertoireFromDto(r));
        }

        public bool RemoveIntervention(InterventionDto i)
        {
            return DataAcces.RemoveIntervention(InterventionFromDto(i));
        }

        public int GetMaxUserID()
        {
            return DataAcces.ObtainMaxIDUser();
        }

        public int Login(string login, string password)
        {
            Utilisateurs tmp = DataAcces.SelectUtilisateur(login, password);

            if (tmp != null)
            {
                return tmp.ID;
            }
            return -1;
        }

        public UtilisateurDto LoginUser(string login, string password)
        {
            Utilisateurs u = DataAcces.SelectUtilisateur(login, password);
            return new UtilisateurDto
                {
                    ID = u.ID,
                    Nom = u.Nom,
                    Prenom = u.Prenom,
                    Adresse = u.Adresse,
                    NTel = u.NTel,
                    Email = u.Email,
                    Photo = BLLUtilities.BinaryToImg(u.Photo),
                    Login = u.Login,
                    Password = u.Password
                };
        }

        public IEnumerable<RepertoireDto> SelectAllRepertoireAsEnum(int IDUtilisateur)
        {
            return DataAcces.SelectAllRepertoire(IDUtilisateur).Select(
                r => new RepertoireDto
                {
                    IDUtilisateur = r.IDUtilisateur,
                    IDContact = r.IDContact,
                    Nom = r.Nom,
                    Prenom = r.Prenom,
                    Adresse = r.Adresse,
                    NTel = r.NTel,
                    Email = r.Email,
                    Photo = BLLUtilities.BinaryToImg(r.Photo),
                    Priorite = r.Priorite
                }
            ).AsEnumerable<RepertoireDto>();
        }
    }
}
