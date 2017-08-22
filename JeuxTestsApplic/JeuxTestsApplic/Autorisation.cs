using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JeuxTestsApplic
{
    public class Autorisation
    {
        #region PROPERTIES
        private bool[] tab = new bool[48];
        private int CaseDepart;
        private int CaseFin;
        private int Case;
        #endregion

        #region CONSTRUCTEUR
        public Autorisation()
        {
            for (int i = 0; i < 48; i++) { tab[i] = false; }
            CaseDepart = 0;
            CaseFin = 0;
            Case = 0;
        }
        #endregion

        #region INDEXED ACCESSOR + stringSplit
        public bool this[int i]
        {
            get
            {
                return tab[i];
            }
            set
            {
                tab[i] = value;
            }
        }

        public bool this[String period]
        {
            get
            {
                bool access = true;
                stringSplit(period);
                Case = CaseDepart;
                do {
                    if (!tab[Case]) access= false;
                    Case++;
                } while (Case < CaseFin && access);
                return access;
            }
            set
            {
                stringSplit(period);
                Case = CaseDepart;
                do
                {
                    tab[Case] = value;
                    Case++;
                } while (Case < CaseFin);
            }
        }

        public void stringSplit(string str)
        {
            if (str.Contains('-'))
            {
                string[] temp = str.Split('-');
                string[] tempStart = temp[0].Split('h');
                string[] tempEnd = temp[1].Split('h');

                CaseDepart = 2 * (Convert.ToInt32(tempStart[0]));
                if (tempStart[1] == "30") CaseDepart++;

                CaseFin = 2 * (Convert.ToInt32(tempEnd[0]));
                if (tempEnd[1] == "30") CaseFin++;
            }
            else
            {
                string[] temp = str.Split('h');
                CaseDepart = 2 * (Convert.ToInt32(temp[0]));
                if (temp[1] == "30") CaseDepart++;
                CaseFin = CaseDepart;
            }
        }
        #endregion
    }
}
