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

namespace Tickets.Resources.Pages.Tables.RacePage
{
    /// <summary>
    /// Логика взаимодействия для RaceView.xaml
    /// </summary>
    public partial class RaceView : Page
    {
        public RaceView()
        {
            InitializeComponent();
            dg_race.ItemsSource = AppData.getContext().Race.ToList();
            addBtns();
        }

        private void addBtns()
        {

            Button btn_del = new Button();
            Button btn_add = new Button();

            btn_add.Content = "Добавить";
            btn_del.Content = "Удалить";

            btn_del.Click += (sender, e) => AppData.DeleteItems<User>(dg_race);
            
            AppData.dockPanel.Children.Add(btn_add);
            AppData.dockPanel.Children.Add(btn_del);
        }
    }
}
