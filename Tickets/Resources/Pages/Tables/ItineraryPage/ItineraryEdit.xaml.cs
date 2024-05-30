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

namespace Tickets.Resources.Pages.Tables.ItineraryPage
{
    /// <summary>
    /// Логика взаимодействия для ItineraryEdit.xaml
    /// </summary>
    public partial class ItineraryEdit : Page
    {
        Itinary _current = new Itinary();
        bool newIns = true;
        public ItineraryEdit(Itinary itinary)
        {
            InitializeComponent();
            AppData.dockPanel.Children.Clear();
            //init page
            if (itinary != null)
            {
                _current = itinary;
                newIns = false;
            }
            cb_startPoint.ItemsSource = AppData.getContext().Destination.ToList();
            cb_endPoint.ItemsSource = AppData.getContext().Destination.ToList();
            DataContext = _current;
        }
        private static int getNextId(Itinary current)
        {
            try
            {
                int id = AppData.getContext().Itinary.ToList().Last().ItinaryID;
                return id + 1;
            }
            catch { return 0; }
        }

        private void btn_save_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (cb_startPoint.SelectedItem == null) errors.AppendLine("Выберите точку отправки;");
            if (cb_endPoint.SelectedItem == null) errors.AppendLine("Выберите точку прибытия;");
            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }


            if (_current.ItinaryID>= 0)
            {
                Destination start = cb_startPoint.SelectedItem as Destination;
                Destination end = cb_endPoint.SelectedItem as Destination;
                _current.ItinaryName = start.Adress + " -> " + end.Adress;
                if (newIns)
                {
                    _current.ItinaryID= getNextId(_current);
                }
                AppData.getContext().Itinary.AddOrUpdate(_current);
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
