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
    public partial class EditDeviceSettingsForm : Form
    {
        public Appareil refApp { get; set; }
        public EditDeviceSettingsForm(Appareil app)
        {
            InitializeComponent();
            refApp = app;
            comboBoxType.DataSource = Enum.GetValues(typeof(TypeAppareil));
            comboBoxType.SelectedIndex = (int)refApp.Type;
            textBoxConso.Text = refApp.Consommation.ToString();
            textBoxMarque.Text = refApp.Marque;
            textBoxModele.Text = refApp.Modele;
            textBoxnumSerie.Text = refApp.NumeroSerie;
            labelError.Hide();
        }

        public string ModeleTextBox()
        {
            if (String.IsNullOrEmpty(textBoxModele.Text))
                return "Unknown";
            else
                return textBoxModele.Text;
        }

        private void buttonAutorisation_Click(object sender, EventArgs e)
        {
            FormAutorisation formAutorisation = new FormAutorisation(refApp);
            formAutorisation.ShowDialog();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            if (comboBoxType.SelectedItem != null) //if user made change
            {
                if (comboBoxType.SelectedItem.ToString().Equals(TypeAppareil.Electromenager.ToString()))
                    refApp.Type = TypeAppareil.Electromenager;
                else if (comboBoxType.SelectedItem.ToString().Equals(TypeAppareil.Media.ToString()))
                    refApp.Type = TypeAppareil.Media;
                else if (comboBoxType.SelectedItem.ToString().Equals(TypeAppareil.Chauffage.ToString()))
                    refApp.Type = TypeAppareil.Chauffage;
                else if (comboBoxType.SelectedItem.ToString().Equals(TypeAppareil.Eclairage.ToString()))
                    refApp.Type = TypeAppareil.Eclairage;
                else if (comboBoxType.SelectedItem.ToString().Equals(TypeAppareil.Autre.ToString()))
                    refApp.Type = TypeAppareil.Autre;
            }

            if (String.IsNullOrEmpty(textBoxMarque.Text))
                refApp.Marque = "Unknown";
            else
                refApp.Marque = textBoxMarque.Text;

            if (String.IsNullOrEmpty(textBoxModele.Text))
                refApp.NumeroSerie = "Unknow";
            else
                refApp.NumeroSerie = textBoxModele.Text;

            if (String.IsNullOrEmpty(textBoxConso.Text))
                labelError.Show();
            else
            {
                refApp.Consommation = Double.Parse(textBoxConso.Text);

                refApp.DateMiseEnService = dateTimePicker1.Value.Date;
                Close();
            }
        }
    }
}
