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

namespace Tickets.Resources.Pages.Tables.AutobusPage
{
    /// <summary>
    /// Логика взаимодействия для AutobusView.xaml
    /// </summary>
    public partial class AutobusView : Page
    {
        public AutobusView()
        {
            InitializeComponent();
            dg_bus.ItemsSource = AppData.getContext().Autobus.ToList();
            AppData.AddDock<Autobus>(dg_bus, () => AppData.mFrame.Navigate(new AutobusPage.AutobusEdit(null)));
        }

        private void editBtn_Click(object sender, RoutedEventArgs e)
        {
            AppData.mFrame.Navigate(new AutobusPage.AutobusEdit((sender as Button).DataContext as Autobus));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            dg_bus.ItemsSource = AppData.getContext().Autobus.ToList();

            if (!string.IsNullOrEmpty(tb_search.Text))
            {
                List<Autobus> list = dg_bus.ItemsSource as List<Autobus>;
                if (list != null)
                {
                    string filter = tb_search.Text; // Получаем текст из TextBox
                    List<Autobus> filteredList = list.FindAll(autobus => autobus.BusModel.IndexOf(filter, StringComparison.OrdinalIgnoreCase) >= 0);
                    dg_bus.ItemsSource = filteredList;
                }
            }
            else
            {
                dg_bus.ItemsSource = AppData.getContext().User.ToList();
            }
        }
    }
}
