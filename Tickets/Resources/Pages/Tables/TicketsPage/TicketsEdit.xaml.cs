using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
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
using TicketSeller.Resources.LibsAndDictionary;

namespace Tickets.Resources.Pages.Tables.TicketsPage
{
    /// <summary>
    /// Логика взаимодействия для TicketsEdit.xaml
    /// </summary>
    public partial class TicketsEdit : Page
    {
        Ticket _current = new Ticket();
        bool newIns = true;

        public TicketsEdit(Ticket ticket)
        {
            InitializeComponent();
            AppData.dockPanel.Children.Clear();
            if(ticket!=null)
            {
                dtDatePurchase.SelectedDate = ticket.PurchaseDate;
                _current = ticket;
            }
            dtDatePurchase.SelectedDate = DateTime.Now;
            cbBuyer.ItemsSource = AppData.getContext().Buyer.ToList();
            cbRace.ItemsSource = AppData.getContext().Race.ToList();
        }

        private static int getNextId(Ticket current)
        {
            try
            {
                int id = AppData.getContext().Ticket.ToList().Last().TicketID;
                return id + 1;
            }
            catch { return 0; }
        }

        private void btn_save_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (cbBuyer.SelectedItem == null) errors.AppendLine("Выберите автобус;");
            if (cbRace.SelectedItem == null) errors.AppendLine("Выберите рейс;");
            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }


            if (_current.TicketID >= 0)
            {
                _current.PurchaseDate = dtDatePurchase.SelectedDate.Value;
                 Race race = cbRace.SelectedItem as Race;
                _current.Price = race.Price;
                if (newIns)
                {
                    _current.TicketID = getNextId(_current);
                    Buyer buyer = cbBuyer.SelectedItem as Buyer;
                    _current.BuyerID = buyer.BuyerID;

                    _current.RaceID = race.RaceID;
                }
                AppData.getContext().Ticket.AddOrUpdate(_current);
                try
                {
                    AppData.getContext().SaveChanges();
                    MessageBox.Show("Данные сохранены.");
                    AppData.mFrame.GoBack();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка\n" + ex.Message);
                }
            }
        }
    }
}
