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
using Tickets.Resources.LibsAndDictionary;
using Tickets.Resources.LibsAndDitcionary;

namespace Tickets.Resources.Pages.Tables.DestinationPage
{
    /// <summary>
    /// Логика взаимодействия для DestinationView.xaml
    /// </summary>
    public partial class DestinationView : Page
    {
        public DestinationView()
        {
            InitializeComponent();
            dg_destinatoin.ItemsSource = AppData.getContext().Destination.ToList();
            AppData.AddDock<Destination>(dg_destinatoin, () => AppData.mFrame.Navigate(new DestinationPage.DestinationEdit(null)));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            dg_destinatoin.ItemsSource = AppData.getContext().Destination.ToList();

            if (!string.IsNullOrEmpty(tb_search.Text))
            {
                
                List<Destination> list = dg_destinatoin.ItemsSource as List<Destination>; 
                if (list != null) 
                {
                    string filter = tb_search.Text; 
                    List<Destination> filteredList = list.FindAll(destination => destination.Adress.IndexOf(filter, StringComparison.OrdinalIgnoreCase) >= 0); 
                    dg_destinatoin.ItemsSource = filteredList; 
                }
            }
            else
            {
                dg_destinatoin.ItemsSource = AppData.getContext().Destination.ToList();
            }

        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            AppData.getContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
            dg_destinatoin.ItemsSource = AppData.getContext().Destination.ToList();
        }

        private void editBtn_Click(object sender, RoutedEventArgs e)
        {
            AppData.mFrame.Navigate(new DestinationPage.DestinationEdit((sender as Button).DataContext as Destination));
        }
    }
}
