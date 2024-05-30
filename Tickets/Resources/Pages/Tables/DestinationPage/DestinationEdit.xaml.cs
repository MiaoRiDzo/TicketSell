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

namespace Tickets.Resources.Pages.Tables.DestinationPage
{
    /// <summary>
    /// Логика взаимодействия для DestinationEdit.xaml
    /// </summary>
    public partial class DestinationEdit : Page
    {
        Destination _current = new Destination();
        bool newIns = true;

        public DestinationEdit(Destination destination)
        {
            InitializeComponent();
            AppData.dockPanel.Children.Clear();
            //init page
            if (destination != null)
            {
                _current = destination;
                newIns = false;
            }
            DataContext = _current;
        }
        private static int getNextId(Destination current)
        {
            try
            {
                int id = AppData.getContext().Destination.ToList().Last().DestinationID;
                return id + 1;
            }
            catch { return 0; }
        }

        private void btn_save_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (String.IsNullOrEmpty(tb_adress.Text)) errors.AppendLine("Введите адрес остановки;");


            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }


            if (_current.DestinationID>= 0)
            {
                if (newIns)
                {
                    _current.DestinationID = getNextId(_current);
                }
                AppData.getContext().Destination.AddOrUpdate(_current);
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
