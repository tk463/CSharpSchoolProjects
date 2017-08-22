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
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom d'interface "IService1" à la fois dans le code et le fichier de configuration.
    [ServiceContract]
    public interface IMainService
    {

        [OperationContract]
        int Login(string login, string password);

        [OperationContract]
        IEnumerable<RepertoireDto> GetRepertoire(int IDUtilisateur);

        [OperationContract]
        void UpdateRepertoire(RepertoireDto RepDto);

        [OperationContract]
        IEnumerable<InterventionDto> GetInterventions(int IDUtilisateur);
    }
}
