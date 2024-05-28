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
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            AppData.AddDock<Race>(dg_race, () => AppData.mFrame.Navigate(new RacePage.RaceEdit(null)));
        }
    }
}
