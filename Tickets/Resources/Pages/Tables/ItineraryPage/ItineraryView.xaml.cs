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

namespace Tickets.Resources.Pages.Tables.ItineraryPage
{
    /// <summary>
    /// Логика взаимодействия для ItineraryView.xaml
    /// </summary>
    public partial class ItineraryView : Page
    {
        public ItineraryView()
        {
            InitializeComponent();
            dg_itinary.ItemsSource = AppData.getContext().Itinary.ToList();
            addBtns();
        }

        private void addBtns()
        {

            Button btn_del = new Button();
            Button btn_add = new Button();

            btn_add.Content = "Добавить";
            btn_del.Content = "Удалить";

            btn_del.Click += (sender, e) => AppData.DeleteItems<Itinary>(dg_itinary);
            AppData.dockPanel.Children.Add(btn_add);
            AppData.dockPanel.Children.Add(btn_del);
        }
    }
}
