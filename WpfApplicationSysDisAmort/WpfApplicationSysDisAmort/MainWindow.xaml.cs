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
using WpfApplicationSysDisAmort.ServiceCurrencyConvertor;

namespace WpfApplicationSysDisAmort
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        CurrencyConvertorSoapClient CCSoap;

        public MainWindow()
        {
            InitializeComponent();
            CBDeviseEnd.ItemsSource = Currency.GetValues(typeof(Currency)).Cast<Currency>();
            CCSoap = new CurrencyConvertorSoapClient();
            //{System.ServiceModel.ChannelFactoryRefCache<WpfApplicationSysDisAmort.ServiceCurrencyConvertor.CurrencyConvertorSoap>.EndpointTraitComparer}
        }

        private void BGo_Click(object sender, RoutedEventArgs e)
        {
            Paragraph myParag = new Paragraph();
            double convert = CCSoap.ConversionRate(Currency.EUR, (Currency)CBDeviseEnd.SelectedItem);
            myParag.Inlines.Add("Convert data : " + convert + "\n");

            /*double capital = double.Parse(TBMontant.Text);
            capital =

            int nbMois = int.Parse(TBDuree.Text);
            double EchAn = (capital / nbMois) * 12;
            double tempY = 1 / EchAn;
            double tempX = 1 + (double.Parse(TBTaux.Text.Replace('.',',')));
            double TxPerio = Math.Pow(tempX, tempY) +1;

            myParag.Inlines.Add("Tx periodique : " + TxPerio + "\n");

            tempX = capital * TxPerio;
            tempY = 1 - Math.Pow(1 + TxPerio, -nbMois);
            double Ech = tempX / tempY;

            myParag.Inlines.Add("Echeance : " + Ech + "\n");*/


            RTB.Document.Blocks.Clear();
            RTB.Document.Blocks.Add(myParag);
        }
    }
}
