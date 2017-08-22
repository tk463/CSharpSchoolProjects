using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EnergyLib;

namespace OptimizeEnergy
{
    public partial class FormAutorisation : Form
    {
        public Appareil refApp { get; set; }
        public List<CheckBox> checkBoxList { get; set; }
        public FormAutorisation(Appareil app)
        {
            InitializeComponent();
            CenterToParent();
            refApp = app;
            checkBoxList = new List<CheckBox>();

            #region blablaAddDatCheckBoxRegion
            checkBoxList.Add(checkBox1);
            checkBoxList.Add(checkBox2);
            checkBoxList.Add(checkBox3);
            checkBoxList.Add(checkBox4);
            checkBoxList.Add(checkBox5);
            checkBoxList.Add(checkBox6);
            checkBoxList.Add(checkBox7);
            checkBoxList.Add(checkBox8);
            checkBoxList.Add(checkBox9);
            checkBoxList.Add(checkBox10);
            checkBoxList.Add(checkBox11);
            checkBoxList.Add(checkBox12);
            checkBoxList.Add(checkBox13);
            checkBoxList.Add(checkBox14);
            checkBoxList.Add(checkBox15);
            checkBoxList.Add(checkBox16);
            checkBoxList.Add(checkBox17);
            checkBoxList.Add(checkBox18);
            checkBoxList.Add(checkBox19);
            checkBoxList.Add(checkBox20);
            checkBoxList.Add(checkBox21);
            checkBoxList.Add(checkBox22);
            checkBoxList.Add(checkBox23);
            checkBoxList.Add(checkBox24);
            checkBoxList.Add(checkBox25);
            checkBoxList.Add(checkBox26);
            checkBoxList.Add(checkBox27);
            checkBoxList.Add(checkBox28);
            checkBoxList.Add(checkBox29);
            checkBoxList.Add(checkBox30);
            checkBoxList.Add(checkBox31);
            checkBoxList.Add(checkBox32);
            checkBoxList.Add(checkBox33);
            checkBoxList.Add(checkBox34);
            checkBoxList.Add(checkBox35);
            checkBoxList.Add(checkBox36);
            checkBoxList.Add(checkBox37);
            checkBoxList.Add(checkBox38);
            checkBoxList.Add(checkBox39);
            checkBoxList.Add(checkBox40);
            checkBoxList.Add(checkBox41);
            checkBoxList.Add(checkBox42);
            checkBoxList.Add(checkBox43);
            checkBoxList.Add(checkBox44);
            checkBoxList.Add(checkBox45);
            checkBoxList.Add(checkBox46);
            checkBoxList.Add(checkBox47);
            checkBoxList.Add(checkBox48);
            #endregion

            for (int i = 0; i < checkBoxList.Count; i++)
            {
                if (refApp.Autorisation[i] == true)
                    checkBoxList[i].Checked = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 48; i++)
            {
                refApp.Autorisation[i] = checkBoxList[i].Checked;
            }
            Close();
        }
    }
}
