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

namespace Tickets.Resources.Windows
{
    /// <summary>
    /// Логика взаимодействия для MainWin.xaml
    /// </summary>
    public partial class MainWin : Window
    {
        public MainWin()
        {
            InitializeComponent();
            tb_userName.Text = tb_userName.Text + AppData.authUser.UserName;
            tb_userRole.Text = AppData.authUser.Role.RoleName;
            AppData.mFrame = this.mFrame;
            AppData.dockPanel = this.dockPanel;
            AppData.mFrame.Navigate(new Pages.MainPage());
        }

        private void btn_exit_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Сменить пользователя?", AppData.authUser.UserName, MessageBoxButton.OKCancel);
            if (result == MessageBoxResult.OK)
            {
                AppData.authUser = null;
                LoginWindow loginWindow = new LoginWindow();
                loginWindow.Show();
                this.Close();
            }
        }

        private void btn_back_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                mFrame.GoBack();
            }
            catch { }
        }
    }
}
