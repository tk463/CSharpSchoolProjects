using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using PhoneAppSmartVigi.Resources;
using PhoneAppSmartVigi.ServiceReference;

namespace PhoneAppSmartVigi
{
    public partial class LoginPage : PhoneApplicationPage
    {
        private ServicePhoneClient WCFProxy;

        // Constructeur
        public LoginPage()
        {
            InitializeComponent();
            WCFProxy = new ServicePhoneClient();

            // Exemple de code pour la localisation d'ApplicationBar
            //BuildLocalizedApplicationBar();
        }

        private void BLogin_Click(object sender, RoutedEventArgs e)
        {
            if (TBLogin.Text.Equals("") || TBPwd.Password.Equals(""))
            {
                MessageBox.Show("Données manquantes !", "Attention", MessageBoxButton.OK);
            }
            else
            {
                WCFProxy.LoginPhoneCompleted += WCFProxy_LoginPhoneCompleted;
                WCFProxy.LoginPhoneAsync(TBLogin.Text, TBPwd.Password);
            }
        }

        void WCFProxy_LoginPhoneCompleted(object sender, LoginPhoneCompletedEventArgs e)
        {
            WCFProxy.LoginPhoneCompleted -= WCFProxy_LoginPhoneCompleted;
            if (e.Result == null)
            {
                MessageBox.Show("Utilisateur inexistant !", "Attention", MessageBoxButton.OK);
            }
            else
            {
                PhoneApplicationService.Current.State["Utilisateur"] = e.Result;
                NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
            }
        }

        // Exemple de code pour la conception d'une ApplicationBar localisée
        //private void BuildLocalizedApplicationBar()
        //{
        //    // Définit l'ApplicationBar de la page sur une nouvelle instance d'ApplicationBar.
        //    ApplicationBar = new ApplicationBar();

        //    // Crée un bouton et définit la valeur du texte sur la chaîne localisée issue d'AppResources.
        //    ApplicationBarIconButton appBarButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/appbar.add.rest.png", UriKind.Relative));
        //    appBarButton.Text = AppResources.AppBarButtonText;
        //    ApplicationBar.Buttons.Add(appBarButton);

        //    // Crée un nouvel élément de menu avec la chaîne localisée d'AppResources.
        //    ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarMenuItemText);
        //    ApplicationBar.MenuItems.Add(appBarMenuItem);
        //}
    }
}