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
using System.Windows.Shapes;
using Tickets.Resources.LibsAndDictionary;
using Tickets.Resources.LibsAndDitcionary;

namespace Tickets.Resources.Windows.moreDetailsWins
{
    /// <summary>
    /// Логика взаимодействия для DetailsTicket.xaml
    /// </summary>
    public partial class ticketsFilter : Window
    {
        public ticketsFilter(Buyer buyer)
        {
            InitializeComponent();
            List<Ticket> tickets = AppData.getContext().Ticket.ToList();
            List<Ticket> list = new List<Ticket>();
            foreach (Ticket _current in tickets)
            {
                if(_current.BuyerID == buyer.BuyerID)
                {
                    list.Add(_current);
                }
            }
            dg_ticket.ItemsSource = list;
        }

        private void closeBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
