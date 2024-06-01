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
using Tickets.Resources.Windows.moreDetailsWins;

namespace Tickets.Resources.Pages.Tables.BuyerPage
{
    /// <summary>
    /// Логика взаимодействия для BuyerView.xaml
    /// </summary>
    public partial class BuyerView : Page
    {
        public BuyerView()
        {
            InitializeComponent();
            dg_buyer.ItemsSource = AppData.getContext().Buyer.ToList();
        }

        private void editBtn_Click(object sender, RoutedEventArgs e)
        {
            AppData.mFrame.Navigate(new BuyerPage.BuyerEdit((sender as Button).DataContext as Buyer));
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            AppData.AddDock<Buyer>(dg_buyer, () => AppData.mFrame.Navigate(new BuyerPage.BuyerEdit(null)));
            AppData.getContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
            dg_buyer.ItemsSource = AppData.getContext().Buyer.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            dg_buyer.ItemsSource = AppData.getContext().Buyer.ToList();

            if (!string.IsNullOrEmpty(tb_search.Text))
            {
                List<Buyer> list = dg_buyer.ItemsSource as List<Buyer>;
                if (list != null)
                {
                    string filter = tb_search.Text; // Получаем текст из TextBox
                    List<Buyer> filteredList = list.FindAll(buyer => buyer.FullName.IndexOf(filter, StringComparison.OrdinalIgnoreCase) >= 0);
                    dg_buyer.ItemsSource = filteredList;
                }
            }
            else
            {
                dg_buyer.ItemsSource = AppData.getContext().Buyer.ToList();
            }

        }

        private void moreBtn_Click(object sender, RoutedEventArgs e)
        {
            ticketsFilter ticketsFilter = new ticketsFilter((sender as Button).DataContext as Buyer);
            ticketsFilter.Show();
        }
    }
} 
