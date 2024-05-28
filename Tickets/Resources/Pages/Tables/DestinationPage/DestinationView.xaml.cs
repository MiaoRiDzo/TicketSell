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

        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            AppData.AddDock<Destination>(dg_destinatoin, () => AppData.mFrame.Navigate(new DestinationPage.DestinationEdit(null)));
        }
    }
}
