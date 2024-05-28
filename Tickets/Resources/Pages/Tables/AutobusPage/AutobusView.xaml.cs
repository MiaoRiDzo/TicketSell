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
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            AppData.AddDock<Autobus>(dg_bus, () => AppData.mFrame.Navigate(new AutobusPage.AutobusEdit(null)), delItems);
        }

        private void delItems()
        {
            var removes = dg_bus.SelectedItems.Cast<Autobus>().ToList();
            if (MessageBox.Show($"Вы точно хотите удалить следующие {removes.Count()} элементы?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    AppData.getContext().Autobus.RemoveRange(removes);
                    AppData.getContext().SaveChanges();
                    MessageBox.Show("Данные удалены");
                    dg_bus.ItemsSource = AppData.getContext().Autobus.ToList();
                }
                catch (Exception ex) { MessageBox.Show(ex.Message.ToString()); }
            }
        }
    }
}
