using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Security.Cryptography;
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
using System.Xml.Linq;
using Tickets.Resources.LibsAndDictionary;
using Tickets.Resources.LibsAndDitcionary;
using TicketSeller.Resources.LibsAndDictionary;

namespace Tickets.Resources.Pages.Tables.UserPage
{
    /// <summary>
    /// Логика взаимодействия для UserEdit.xaml
    /// </summary>
    public partial class UserEdit : Page
    {
        User _current = new User();
        bool newIns = true;
        public UserEdit(User user)
        {
            InitializeComponent();
            AppData.dockPanel.Children.Clear();

            //init page
            if (user != null)
            {
                _current = user;
                newIns = false;
            }
            cbRole.ItemsSource = AppData.getContext().Role.ToList();
            DataContext = _current;
            
        }
        private static int getNextId(User current)
        {
            try
            {
                int id = AppData.getContext().User.ToList().Last().UserID;
                return id + 1;
            }
            catch { return 0; }
        }

        private void btn_save_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (String.IsNullOrEmpty(tb_fullName.Text)) errors.AppendLine("Введите имя польхователя;");
            if (String.IsNullOrEmpty(tb_login.Text)) errors.AppendLine("Введите логин;");
            if (String.IsNullOrEmpty(tb_password.Password)) errors.AppendLine("Введите пароль;");
            if (cbRole.SelectedItem == null) errors.AppendLine("Выберите должность;");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }


            if (_current.UserID >= 0)
            {
                _current.UserPassword = MD5Hash.StringToMD5(tb_password.Password);
                if (newIns)
                {
                    _current.UserID = getNextId(_current);
                    Role role = cbRole.SelectedItem as Role;
                    _current.RoleID = role.RoleID;
                }
                AppData.getContext().User.AddOrUpdate(_current);
                try
                {
                    AppData.getContext().SaveChanges();
                    MessageBox.Show("Данные сохранены.");
                    AppData.mFrame.GoBack();
                }catch(Exception ex)
                {
                    MessageBox.Show("Ошибка\n" + ex.Message);
                }
            }
        }
    }
}
