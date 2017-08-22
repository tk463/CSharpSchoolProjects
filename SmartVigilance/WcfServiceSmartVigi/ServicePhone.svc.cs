using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using BLL;

namespace WcfServiceSmartVigi
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "ServicePhone" à la fois dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez ServicePhone.svc ou ServicePhone.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public class ServicePhone : IServicePhone
    {
        private BLLSmartVigi BLLAccess;

        public ServicePhone()
        {
            BLLAccess = new BLLSmartVigi();
            BLLAccess.StartDAL();
        }

        public UtilisateurPhone LoginPhone(string login, string password)
        {
            UtilisateurDto uDto = BLLAccess.LoginUser(login, password);
            return new UtilisateurPhone
            {
                Adresse = uDto.Adresse,
                Email = uDto.Email,
                ID = uDto.ID,
                Login = uDto.Login,
                Password = uDto.Password,
                Nom = uDto.Nom,
                NTel = uDto.NTel,
                Prenom = uDto.Prenom
            };
        }

        public IEnumerable<RepertoirePhone> GetRepertoire(int IDUtilisateur)
        {
            List<RepertoireDto> temp = BLLAccess.SelectAllRepertoireAsEnum(IDUtilisateur).ToList();
            List<RepertoirePhone> phone = new List<RepertoirePhone>();

            foreach (RepertoireDto item in temp)
            {
                phone.Add(new RepertoirePhone
                    {
                        Adresse = item.Adresse,
                        Email = item.Email,
                        IDContact = item.IDContact,
                        IDUtilisateur = item.IDUtilisateur,
                        Nom = item.Nom,
                        NTel = item.NTel,
                        Prenom = item.Prenom,
                        Priorite = item.Priorite
                    });
            }

            return phone;
        }

        public void DoIntervention(InterventionDto interv)
        {
            BLLAccess.InsertIntervention(interv);
        }
    }
}
