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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApplicationSysDis.ServiceReferenceWS;

namespace WpfApplicationSysDis
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        WSSoapClient WSLink;

        public MainWindow()
        {
            InitializeComponent();
            WSLink = new WSSoapClient();
        }

        private void BGo_Click(object sender, RoutedEventArgs e)
        {
            ServiceReferenceWS.dataOut test = WSLink.PlayerData(int.Parse(TBPlayerID.Text));
            Paragraph myParagraph = new Paragraph();
            myParagraph.Inlines.Add("Wins : " + test.Wins + "\n");
            myParagraph.Inlines.Add("Losses : " + test.Losses + "\n");
            myParagraph.Inlines.Add("Played : " + test.Played + "\n");
            foreach (var partie in test.Parties)
            {
                myParagraph.Inlines.Add("Partie : " + partie.id + " DateTime : " + partie.dateheure + " Player1 : " + partie.player1.id + " Player2 : " + partie.player2.id +
                    " Status : " + partie.status+ "\n");
            }
            RTBDataOut.Document.Blocks.Add(myParagraph);
        }


    }
}
