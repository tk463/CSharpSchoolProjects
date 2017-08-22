using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BLL;

namespace SmartVigilance
{
    public class WCFLib
    {
        private static ServiceReference.MainServiceClient WCFProxy;

        public static void Init()
        {
            WCFProxy = new ServiceReference.MainServiceClient();
        }

        public static int Login(string Login, string Passwd)
        {
            if (WCFProxy == null)
                throw new Exception("WCFProxy non initialisé");

            return WCFProxy.Login(Login, Passwd);
        }

        public static IEnumerable<RepertoireDto> GetRepertoire(int IDUtilisateur)
        {
            if (WCFProxy == null)
                throw new Exception("WCFProxy non initialisé");

            List<RepertoireDto> tempList = WCFProxy.GetRepertoire(IDUtilisateur).ToList();

            tempList.Sort(new PriotityComparer()); //Sort the list on Priotity

            return tempList; //Photos Nope
        }

        public static void UpdateRepertoire(RepertoireDto RepDto)
        {
            if (WCFProxy == null)
                throw new Exception("WCFProxy non initialisé");

            WCFProxy.UpdateRepertoire(RepDto);
        }

        public static IEnumerable<InterventionDto> GetInterventions(int IDUtilisateur)
        {
            if (WCFProxy == null)
                throw new Exception("WCFProxy non initialisé");

            List<InterventionDto> tempList = WCFProxy.GetInterventions(IDUtilisateur).ToList();

            return tempList;
        }
    }

    public class PriotityComparer : IComparer<RepertoireDto>
    {

        public int Compare(RepertoireDto x, RepertoireDto y)
        {
            return x.Priorite.CompareTo(y.Priorite);
        }
    }
}