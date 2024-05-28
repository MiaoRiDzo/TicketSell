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

namespace Tickets.Resources.Pages.Tables.AutobusPage
{
    /// <summary>
    /// Логика взаимодействия для AutobusView.xaml
    /// </summary>
    public partial class AutobusView : Page
    {
        public AutobusView()
        {
            InitializeComponent();
            dg_bus.ItemsSource = AppData.getContext().Autobus.ToList();
        }

        private void addBtns()
        {

            Button btn_del = new Button();
            Button btn_add = new Button();

            btn_add.Content = "Добавить";
            btn_del.Content = "Удалить";

            btn_del.Click += (sender, e) => AppData.DeleteItems<Autobus>(dg_bus);
            
            AppData.dockPanel.Children.Add(btn_add);
            AppData.dockPanel.Children.Add(btn_del);
        }
    }
}
