using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using PhoneAppSmartVigi.ServiceReference;
using System.Windows.Media;

namespace PhoneAppSmartVigi
{
    public partial class MainPage : PhoneApplicationPage
    {
        private ServicePhoneClient WCFProxy;
        private UtilisateurPhone user;
        private List<RepertoirePhone> repertoire;
        private RepertoirePhone smartVigilance;
        private List<int> idCalledPerson;

        public MainPage()
        {
            InitializeComponent();
            WCFProxy = new ServicePhoneClient();
            user = (UtilisateurPhone)PhoneApplicationService.Current.State["Utilisateur"];
            TBUsername.Text = user.Nom + " " + user.Prenom;

            idCalledPerson = new List<int>();

            smartVigilance = new RepertoirePhone
            {
                NTel = "080510504",
                IDContact = 8,
                Nom = "Smart",
                Prenom = "Vigilance",
                Priorite = 0,
                IDUtilisateur = user.ID,
            };

            WCFProxy.GetRepertoireCompleted += WCFProxy_GetRepertoireCompleted;
            WCFProxy.GetRepertoireAsync(user.ID);
        }

        void WCFProxy_GetRepertoireCompleted(object sender, GetRepertoireCompletedEventArgs e)
        {
            repertoire = e.Result.ToList();

            if (repertoire.Count >= 1)
            {
                BRaccourci1.Content = repertoire[0].Nom.Substring(0, 1).ToUpper() + repertoire[0].Prenom.Substring(0, 1).ToUpper();

                BRaccourci1.BorderBrush = new SolidColorBrush(Colors.White);
                BRaccourci1.Click += BRaccourci_Click;
            }
            if (repertoire.Count >= 2)
            {
                BRaccourci2.Content = repertoire[1].Nom.Substring(0, 1).ToUpper() + repertoire[1].Prenom.Substring(0, 1).ToUpper();

                BRaccourci2.BorderBrush = new SolidColorBrush(Colors.White);
                BRaccourci2.Click += BRaccourci_Click;
            }
            if (repertoire.Count >= 3)
            {
                BRaccourci3.Content = repertoire[2].Nom.Substring(0, 1).ToUpper() + repertoire[2].Prenom.Substring(0, 1).ToUpper();

                BRaccourci3.BorderBrush = new SolidColorBrush(Colors.White);
                BRaccourci3.Click += BRaccourci_Click;
            }
            if (repertoire.Count >= 4)
            {
                BRaccourci4.Content = repertoire[3].Nom.Substring(0, 1).ToUpper() + repertoire[3].Prenom.Substring(0, 1).ToUpper();

                BRaccourci4.BorderBrush = new SolidColorBrush(Colors.White);
                BRaccourci4.Click += BRaccourci_Click;
            }
        }

        void BRaccourci_Click(object sender, RoutedEventArgs e)
        {
            int i = 0;
            if (BRaccourci1.Equals(sender))
            {
                i = 0;
            }
            if (BRaccourci2.Equals(sender))
            {
                i = 1;
            }
            if (BRaccourci3.Equals(sender))
            {
                i = 2;
            }
            if (BRaccourci4.Equals(sender))
            {
                i = 3;
            }

            InterventionDto interv = new InterventionDto
            {
                IDUtilisateur = user.ID,
                IDContact = repertoire[i].IDContact,
                DateHeure = DateTime.Now,
                Data = "Appel rapide",
                UrgenceLevel = 2,
                GPSLocation = "random"
            };

            WCFProxy.DoInterventionAsync(interv);
            idCalledPerson.Add(repertoire[i].IDContact);
        }

        private void BHelp_Click(object sender, RoutedEventArgs e)
        {
            // Not Working on emulator
            /*Geolocator geolocator = new Geolocator();
            geolocator.DesiredAccuracyInMeters = 50;

            try
            {
                Geoposition geoposition = await geolocator.GetGeopositionAsync(
                    maximumAge: TimeSpan.FromMinutes(5),
                    timeout: TimeSpan.FromSeconds(10)
                    );

                string position = "[" + geoposition.Coordinate.Latitude.ToString("0.00") + ", "+geoposition.Coordinate.Longitude.ToString("0.00") + "]";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erreur", MessageBoxButton.OK);
            }*/

            InterventionDto interv = new InterventionDto
            {
                IDUtilisateur = user.ID,
                IDContact = smartVigilance.IDContact,
                DateHeure = DateTime.Now,
                Data = "HELP",
                UrgenceLevel = 3,
                GPSLocation = "random"
            };

            WCFProxy.DoInterventionAsync(interv);
            idCalledPerson.Add(smartVigilance.IDContact);
        }

        private void BFamille_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 1; i < repertoire.Count; i++) // slot 0 = smartvigi
            {
                InterventionDto interv = new InterventionDto
                {
                    IDUtilisateur = user.ID,
                    IDContact = repertoire[i].IDContact,
                    DateHeure = DateTime.Now,
                    Data = "Appel famille",
                    UrgenceLevel = 2,
                    GPSLocation = "random"
                };

                WCFProxy.DoInterventionAsync(interv);
                idCalledPerson.Add(repertoire[i].IDContact);
            }
        }

        private void BOK_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 1; i < repertoire.Count; i++) // slot 0 = smartvigi
            {
                InterventionDto interv = new InterventionDto
                {
                    IDUtilisateur = user.ID,
                    IDContact = repertoire[i].IDContact,
                    DateHeure = DateTime.Now,
                    Data = "OK sms",
                    UrgenceLevel = 1,
                    GPSLocation = "random"
                };

                WCFProxy.DoInterventionAsync(interv);
                idCalledPerson.Add(repertoire[i].IDContact);
            }
        }

        private void TBUsername_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/DetailsPage.xaml", UriKind.Relative));
        }
    }
}