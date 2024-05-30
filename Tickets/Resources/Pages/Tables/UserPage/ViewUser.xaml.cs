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

namespace Tickets.Resources.Pages.Tables.UserPage
{
    /// <summary>
    /// Логика взаимодействия для ViewUser.xaml
    /// </summary>
    public partial class ViewUser : Page
    {
        public ViewUser()
        {
            InitializeComponent();
            dg_user.ItemsSource = AppData.getContext().User.ToList();
            
            
        }

        private void editBtn_Click(object sender, RoutedEventArgs e)
        {
            AppData.mFrame.Navigate(new UserPage.UserEdit((sender as Button).DataContext as User));
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            AppData.AddDock<User>(dg_user, () => AppData.mFrame.Navigate(new UserPage.UserEdit(null)));
            AppData.getContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
            dg_user.ItemsSource = AppData.getContext().User.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            dg_user.ItemsSource = AppData.getContext().User.ToList();

            if (!string.IsNullOrEmpty(tb_search.Text))
            {
                List<User> list = dg_user.ItemsSource as List<User>;
                if (list != null) 
                {
                    string filter = tb_search.Text; // Получаем текст из TextBox
                    List<User> filteredList = list.FindAll(user => user.UserName.IndexOf(filter, StringComparison.OrdinalIgnoreCase) >= 0); 
                    dg_user.ItemsSource = filteredList; 
                }
            }
            else
            {
                dg_user.ItemsSource = AppData.getContext().User.ToList();
            }

        }
    }
    
}
