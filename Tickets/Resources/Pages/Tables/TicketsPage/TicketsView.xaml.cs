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
    /// Логика взаимодействия для TicketsView.xaml
    /// </summary>
    public partial class TicketsView : Page
    {
        public TicketsView()
        {
            InitializeComponent();
            dg_tickets.ItemsSource = AppData.getContext().Ticket.ToList();
            AppData.AddDock<Ticket>(dg_tickets, () => AppData.mFrame.Navigate(new TicketsPage.TicketsEdit(null)));
        }
    }
}
