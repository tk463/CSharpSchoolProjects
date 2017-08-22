using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using BLL;

namespace WpfApplicationAdmin
{
    /// <summary>
    /// Logique d'interaction pour WindowIntervention.xaml
    /// </summary>
    public partial class WindowIntervention : Window
    {
        private InterventionDto i;

        public InterventionDto Interv
        {
            get { return i; }
        }

        private bool _validated;

        public bool Validated
        {
            get { return _validated; }
        }

        
        public WindowIntervention()
        {
            InitializeComponent();
            i = new InterventionDto();
            _validated = false;
        }

        public WindowIntervention(InterventionDto input)
        {
            InitializeComponent();
            i = input;
            TBData.Text = input.Data;
            TBGPS.Text = input.GPSLocation;
            TBIDContact.Text = input.IDContact.ToString();
            TBIDUser.Text = input.IDUtilisateur.ToString();
            TBUrgence.Text = input.UrgenceLevel.ToString();
            TBDate.Text = input.DateHeure.ToString();
        }

        private void BValidate_Click(object sender, RoutedEventArgs e)
        {
            i.Data = TBData.Text;
            i.GPSLocation = TBGPS.Text;
            i.IDContact = int.Parse(TBIDContact.Text);
            i.IDUtilisateur = int.Parse(TBIDUser.Text);
            i.UrgenceLevel = int.Parse(TBUrgence.Text);
            i.DateHeure = DateTime.Parse(TBDate.Text);
            _validated = true;
            Close();
        }

        private void TBDate_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            TBDate.Text = DateTime.Now.ToString();
        }
    }
}
