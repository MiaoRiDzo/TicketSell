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

namespace Tickets.Resources.Pages.Tables.TicketsPage
{
    /// <summary>
    /// Логика взаимодействия для TicketsVie.xaml
    /// </summary>
    public partial class TicketsView : Page
    {
        public TicketsView()
        {
            InitializeComponent();
            dg_ticket.ItemsSource = AppData.getContext().Ticket.ToList();
            AppData.AddDock<Ticket>(dg_ticket, () => AppData.mainWin.mFrame.Navigate(new TicketsPage.TicketsEdit(null)));

        }

        private void editBtn_Click(object sender, RoutedEventArgs e)
        {
            AppData.mainWin.mFrame.Navigate(new TicketsPage.TicketsEdit((sender as Button).DataContext as Ticket));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            dg_ticket.ItemsSource = AppData.getContext().Ticket.ToList();

            if (!string.IsNullOrEmpty(tb_search.Text))
            {
                List<Ticket> list = dg_ticket.ItemsSource as List<Ticket>;
                if (list != null)
                {
                    string filter = tb_search.Text; // Получаем текст из TextBox
                    List<Ticket> filteredList = list.FindAll(ticket => ticket.Buyer.FullName.IndexOf(filter, StringComparison.OrdinalIgnoreCase) >= 0);
                    dg_ticket.ItemsSource = filteredList;
                }
            }
            else
            {
                dg_ticket.ItemsSource = AppData.getContext().Ticket.ToList();
            }

        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            AppData.AddDock<Ticket>(dg_ticket, () => AppData.mFrame.Navigate(new TicketsPage.TicketsEdit(null)));
            AppData.getContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
            dg_ticket.ItemsSource = AppData.getContext().Ticket.ToList();
        }


    }
}
