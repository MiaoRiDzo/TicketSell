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
        public TicketsView(Ticket ticket)
        {
            InitializeComponent();
            dg_ticket.ItemsSource = AppData.getContext().Ticket.ToList();
            AppData.AddDock<Ticket>(dg_ticket, () => new TicketsPage.TicketsEdit(null));

        }
    }
}
