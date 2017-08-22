using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using BLL;

namespace WcfServiceSmartVigi
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "Service1" dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez Service1.svc ou Service1.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public class MainService : IMainService
    {
        private BLLSmartVigi BLLAccess;

        public MainService()
        {
            BLLAccess = new BLLSmartVigi();
            BLLAccess.StartDAL();
        }

        public int Login(string login, string password)
        {
            return BLLAccess.Login(login, password);
        }

        public IEnumerable<RepertoireDto> GetRepertoire(int IDUtilisateur)
        {
            List<RepertoireDto> temp = BLLAccess.SelectAllRepertoireAsEnum(IDUtilisateur).ToList();
            return temp;
        }

        public void UpdateRepertoire(RepertoireDto RepDto)
        {
            BLLAccess.UpdateRepertoire(RepDto);
            BLLAccess.CommitChanges();
        }

        public IEnumerable<InterventionDto> GetInterventions(int IDUtilisateur)
        {
            List<InterventionDto> temp = BLLAccess.SelectAllInterventionsAsEnum(IDUtilisateur).ToList();
            return temp;
        }
    }
}
