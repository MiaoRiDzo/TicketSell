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

namespace Tickets.Resources.Pages
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void btn_users_Click(object sender, RoutedEventArgs e)
        {
            AppData.mFrame.Navigate(new Pages.Tables.UserPage.ViewUser());
        }

        private void btn_citys_Click(object sender, RoutedEventArgs e)
        {
            AppData.mFrame.Navigate(new Pages.Tables.DestinationPage.DestinationView());
        }

        private void btn_itinerary_Click(object sender, RoutedEventArgs e)
        {
            AppData.mFrame.Navigate(new Pages.Tables.ItineraryPage.ItineraryView());
        }

        private void btn_races_Click(object sender, RoutedEventArgs e)
        {
            AppData.mFrame.Navigate(new Pages.Tables.RacePage.RaceView());
        }

        private void btn_autobus_Click(object sender, RoutedEventArgs e)
        {
            AppData.mFrame.Navigate(new Pages.Tables.AutobusPage.AutobusView());
        }

        private void btn_buyers_Click(object sender, RoutedEventArgs e)
        {
            AppData.mFrame.Navigate(new Pages.Tables.BuyerPage.BuyerView());
        }

    }
}
