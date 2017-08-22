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
    public partial class Adduser : Form
    {
        public User userToSerialize { get; set; }

        public Adduser()
        {
            InitializeComponent();
            CenterToParent();
            labelInfo.Hide();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox1.Text) || String.IsNullOrEmpty(textBox2.Text))
            {
                labelInfo.Text = "Veuillez remplir tout les champs";
                labelInfo.Show();
            }
            else if (!textBox2.Text.Equals(textBox3.Text))
            {
                labelInfo.Text = "Les mots de passe ne correspondent pas";
                labelInfo.Show();
            }
            else
            {
                if (radioButtonAdmin.Checked)
                    userToSerialize = new User(textBox1.Text, textBox2.Text, Profil.Administrateur);
                else
                    userToSerialize = new User(textBox1.Text, textBox2.Text, Profil.Proprietaire);

                Close();
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                buttonOk_Click(this, null);
            }
        }
    }
}
