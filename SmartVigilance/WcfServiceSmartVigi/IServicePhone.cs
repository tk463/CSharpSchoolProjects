using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfServiceSmartVigi
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom d'interface "IServicePhone" à la fois dans le code et le fichier de configuration.
    [ServiceContract]
    public interface IServicePhone
    {
        [OperationContract]
        UtilisateurPhone LoginPhone(string login, string password);

        [OperationContract]
        IEnumerable<RepertoirePhone> GetRepertoire(int IDUtilisateur);

        [OperationContract]
        void DoIntervention(BLL.InterventionDto interv);
    }
}
