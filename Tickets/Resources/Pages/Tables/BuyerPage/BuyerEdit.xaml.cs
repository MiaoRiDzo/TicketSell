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

namespace Tickets.Resources.Pages.Tables.BuyerPage
{
    /// <summary>
    /// Логика взаимодействия для BuyerEdit.xaml
    /// </summary>
    public partial class BuyerEdit : Page
    {
        Buyer _current = new Buyer();
        bool newIns = true;
        public BuyerEdit(Buyer buyer)
        {
            InitializeComponent();
            AppData.dockPanel.Children.Clear();
           
            //init page
            if (buyer != null)
            {
                dtBirthday.SelectedDate = buyer.Birthday;
                _current = buyer;
                newIns = false;
            }
            else
            {
                dtBirthday.SelectedDate = DateTime.Now;
            }

            DataContext = _current;
        }
        private static int getNextId(Buyer current)
        {
            try
            {
                int id = AppData.getContext().Buyer.ToList().Last().BuyerID;
                return id + 1;
            }
            catch { return 0; }
        }

        private void btn_save_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (String.IsNullOrEmpty(tb_fullname.Text)) errors.AppendLine("Введите ФИО;");
            if (String.IsNullOrEmpty(tb_phoneNum.Text)) errors.AppendLine("Введите номер телефона;");
            if (String.IsNullOrEmpty(tb_passport.Text)) errors.AppendLine("Введите номер и серию паспорта;");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }


            if (_current.BuyerID >= 0)
            {
                _current.Birthday = dtBirthday.SelectedDate.Value;
                if (newIns)
                {
                    _current.BuyerID = getNextId(_current);

                }
                AppData.getContext().Buyer.AddOrUpdate(_current);
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
