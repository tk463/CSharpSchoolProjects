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

namespace PhoneAppSmartVigi
{
    public partial class DetailsPage : PhoneApplicationPage
    {
        public DetailsPage()
        {
            InitializeComponent();
            UtilisateurPhone user = (UtilisateurPhone)PhoneApplicationService.Current.State["Utilisateur"];

            TBAdresse.Text = user.Adresse;

            TBUser.Text = user.Nom + " " + user.Prenom;

            TBEmail.Text = user.Email;

            TBLogin.Text = user.Login;
        }
    }
}