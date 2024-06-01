using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
using TicketSeller.Resources.LibsAndDictionary;

namespace Tickets.Resources.Pages.Tables.RacePage
{
    /// <summary>
    /// Логика взаимодействия для RaceEdit.xaml
    /// </summary>
    public partial class RaceEdit : Page
    {
        Race _current = new Race();
        bool newIns = true;
        DatePicker picker = new DatePicker();
        public RaceEdit(Race race)
        {
            InitializeComponent();
            AppData.dockPanel.Children.Clear();
            //init page
            if (race != null)
            {
                _current = race;
                newIns = false;
                dtDataRace.SelectedDate = race.RaceDate;
            }
            else { 
                dtDataRace.SelectedDate = DateTime.Now;
            }
            cbItinary.ItemsSource = AppData.getContext().Itinary.ToList();
            cbAutobus.ItemsSource = AppData.getContext().Autobus.ToList();
            DataContext = _current;
        }

        private static int getNextId(Race current)
        {
            try
            {
                int id = AppData.getContext().Race.ToList().Last().RaceID;
                return id + 1;
            }
            catch { return 0; }
        }

        private void btn_save_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (String.IsNullOrEmpty(tb_raceNum.Text)) errors.AppendLine("Введите номер(название) рейса;");
            if (cbItinary.SelectedItem == null) errors.AppendLine("Выберите маршрут;");
            if (cbAutobus.SelectedItem == null) errors.AppendLine("Выберите автобус;");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }


            if (_current.RaceID >= 0)
            {
                string originalString = tb_price.Text;
                _current.Price = decimal.Parse(originalString.Contains(".") ? originalString.Substring(0, originalString.IndexOf('.')) : originalString);
                _current.RaceDate = dtDataRace.SelectedDate.Value;
                if (newIns)
                {
                    _current.RaceID = getNextId(_current);
                    Itinary itinary = cbItinary.SelectedItem as Itinary;
                    _current.ItinaryID = itinary.ItinaryID;
                    Autobus autobus= cbAutobus.SelectedItem as Autobus;
                    _current.AutobusID = autobus.AutobusID;
                }
                AppData.getContext().Race.AddOrUpdate(_current);
                try
                {
                    AppData.getContext().SaveChanges();
                    MessageBox.Show("Данные сохранены.");
                    AppData.mFrame.GoBack();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка\n" + ex.ToString());
                }
            }
        }

        private void tb_price_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsTextAllowed(e.Text);
        }
        private static bool IsTextAllowed(string text)
        {
            // Регулярное выражение для проверки цифр
            Regex regex = new Regex("[^0-9]+"); // Разрешаем только цифры
            return !regex.IsMatch(text);
        }

        private void NumericTextBox_Pasting(object sender, DataObjectPastingEventArgs e)
        {
            if (e.DataObject.GetDataPresent(typeof(string)))
            {
                string text = (string)e.DataObject.GetData(typeof(string));
                if (!IsTextAllowed(text))
                {
                    e.CancelCommand();
                }
            }
            else
            {
                e.CancelCommand();
            }
        }
    }
}
