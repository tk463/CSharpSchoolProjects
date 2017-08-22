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
using Microsoft.Win32;
using BLL;
using System.Windows.Threading;
using System.Drawing;

namespace WpfApplicationAdmin
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private BLLSmartVigi BLLAccess;

        public MainWindow()
        {
            InitializeComponent();
            BLLAccess = new BLLSmartVigi();
            BLLAccess.StartDAL();

            DispatcherTimer dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += dispatcherTimer_Tick;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Start();

            utilisateurDtoDataGrid.ItemsSource = BLLAccess.SelectAllUtilisateurs();
        }

        void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            this.interventionDtoDataGridDT.ItemsSource = BLLAccess.SelectAllInterventions();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            System.Windows.Data.CollectionViewSource utilisateurDtoViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("utilisateurDtoViewSource")));
            // Charger les données en définissant la propriété CollectionViewSource.Source :
            // utilisateurDtoViewSource.Source = [source de données générique]
            System.Windows.Data.CollectionViewSource repertoireDtoViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("repertoireDtoViewSource")));
            // Charger les données en définissant la propriété CollectionViewSource.Source :
            // repertoireDtoViewSource.Source = [source de données générique]
            System.Windows.Data.CollectionViewSource interventionDtoViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("interventionDtoViewSource")));
            // Charger les données en définissant la propriété CollectionViewSource.Source :
            // interventionDtoViewSource.Source = [source de données générique]
        }

        private void utilisateurDtoDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (e.AddedItems[0] is UtilisateurDto)
	            {
                    repertoireDtoDataGrid.ItemsSource = BLLAccess.SelectAllRepertoire((e.AddedItems[0] as UtilisateurDto).ID);
                    interventionDtoDataGrid.ItemsSource = BLLAccess.SelectAllInterventions((e.AddedItems[0] as UtilisateurDto).ID);
	            }
            }
            catch (Exception)
            {
                //do nothing
            }
            
        }

        private void utilisateurDtoDataGrid_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            if (e.EditAction == DataGridEditAction.Commit)
            {
                if (e.Row.IsNewItem) //new = insert
                {
                    Action action = delegate
                        {
                            BLLAccess.InsertUtilisateur(e.Row.Item as UtilisateurDto);
                            BLLAccess.CommitChanges();
                        };
                    Dispatcher.BeginInvoke(action, System.Windows.Threading.DispatcherPriority.Background);
                    
                }
                else
                {
                    Action action = delegate
                    {
                        BLLAccess.UpdateUtilisateur(e.Row.Item as UtilisateurDto);
                        BLLAccess.CommitChanges();
                    };
                    Dispatcher.BeginInvoke(action, System.Windows.Threading.DispatcherPriority.Background);
                }
            }
        }

        private void utilisateurDtoDataGrid_InitializingNewItem(object sender, InitializingNewItemEventArgs e)
        {
            ((UtilisateurDto)e.NewItem).ID = BLLAccess.GetMaxUserID() + 1;
        }

        private void utilisateurDtoDataGrid_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            DataGrid grid = sender as DataGrid;
            if (e.Key == Key.Delete)
            {
                BLLAccess.RemoveUtilisateur(grid.CurrentItem as UtilisateurDto);
                BLLAccess.CommitChanges();
            }
        }

        private void repertoireDtoDataGrid_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            if (e.EditAction == DataGridEditAction.Commit)
            {
                if (e.Row.IsNewItem)
                {
                    Action action = delegate
                        {
                            BLLAccess.InsertRepertoire(e.Row.Item as RepertoireDto);
                            BLLAccess.CommitChanges();
                        };
                    Dispatcher.BeginInvoke(action, System.Windows.Threading.DispatcherPriority.Background);
                }
                else
                {
                    Action action = delegate
                        {
                            BLLAccess.UpdateRepertoire(e.Row.Item as RepertoireDto);
                            BLLAccess.CommitChanges();
                        };
                    Dispatcher.BeginInvoke(action, System.Windows.Threading.DispatcherPriority.Background);
                }
            }
        }

        private void interventionDtoDataGrid_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            if (e.EditAction == DataGridEditAction.Commit)
            {
                if (e.Row.IsNewItem)
                {
                    Action action = delegate
                        {
                            BLLAccess.InsertIntervention(e.Row.Item as InterventionDto);
                            BLLAccess.CommitChanges();
                        };
                    Dispatcher.BeginInvoke(action, System.Windows.Threading.DispatcherPriority.Background);
                }
                else
                {
                    Action action = delegate
                        {
                            BLLAccess.UpdateIntervention(e.Row.Item as InterventionDto);
                            BLLAccess.CommitChanges();
                        };
                    Dispatcher.BeginInvoke(action, System.Windows.Threading.DispatcherPriority.Background);
                }
            }
        }

        private void utilisateurDtoDataGrid_BeginningEdit(object sender, DataGridBeginningEditEventArgs e)
        {
            if (e.Column.DisplayIndex == 6)
            {
                UtilisateurDto selected = (UtilisateurDto)((DataGrid)sender).CurrentCell.Item;
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.ShowDialog();
                if (ofd.FileName != String.Empty)
                {
                    try
                    {
                        System.Drawing.Image newPhoto = new Bitmap(ofd.FileName);
                        newPhoto = new Bitmap(newPhoto, new System.Drawing.Size(100, 70));
                        selected.Photo = newPhoto;
                    }
                    catch (Exception)
                    {
                        //do nothing
                    }
                }
            }
        }

        private void BInterv_Click(object sender, RoutedEventArgs e)
        {
            WindowIntervention windInterv = new WindowIntervention();
            windInterv.ShowDialog();
            if (windInterv.Validated)
            {
                Action action = delegate
                {
                    BLLAccess.InsertIntervention(windInterv.Interv);
                    BLLAccess.CommitChanges();

                };
                Dispatcher.BeginInvoke(action, System.Windows.Threading.DispatcherPriority.Background);
            }
        }

        private void repertoireDtoDataGrid_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            DataGrid grid = sender as DataGrid;
            if (e.Key == Key.Delete)
            {
                BLLAccess.RemoveRepertoire(grid.CurrentItem as RepertoireDto);
                BLLAccess.CommitChanges();
            }
        }
    }
}
