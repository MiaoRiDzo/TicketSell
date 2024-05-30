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
using TicketSeller.Resources.LibsAndDictionary;

namespace Tickets.Resources.Windows
{
    /// <summary>
    /// Логика взаимодействия для LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void btn_enter_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                List<User> users = AppData.getContext().User.ToList();
                foreach (User user in users)
                {
                    if (user.UserLogin == tb_login.Text)
                    {
                        if (user.UserPassword == MD5Hash.StringToMD5(tb_pass.Password))
                        {
                            AppData.authUser = user;
                            MainWin mainWin = new MainWin();
                            AppData.mainWin = mainWin;
                            mainWin.Show();
                            this.Close();
                        }
                    }
                }
                if (AppData.authUser != null)
                {

                }
                else
                {
                    MessageBox.Show("Введенные данные не верны. Проверьте логин и пароль, или обратитесь к администратору");
                }
            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
