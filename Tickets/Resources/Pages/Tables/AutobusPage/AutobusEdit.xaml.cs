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

namespace Tickets.Resources.Pages.Tables.AutobusPage
{
    /// <summary>
    /// Логика взаимодействия для AutobusEdit.xaml
    /// </summary>
    public partial class AutobusEdit : Page
    {
        bool newIns = true;
        Autobus _current = new Autobus();
        public AutobusEdit(Autobus autobus)
        {
            InitializeComponent();
            AppData.dockPanel.Children.Clear();
            //init page
            if (autobus != null)
            {
                _current = autobus;
                newIns = false;
            }
           
            DataContext = _current;
        }
        private static int getNextId(Autobus current)
        {
            try
            {
                int id = AppData.getContext().Autobus.ToList().Last().AutobusID;
                return id + 1;
            }
            catch { return 0; }
        }

        private void btn_save_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrEmpty(tb_busModel.Text)) errors.AppendLine("Введите модель автобуса;");
            if (string.IsNullOrEmpty(tb_busNum.Text)) errors.AppendLine("Введите номер автобуса;");
            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }


            if (_current.AutobusID >= 0)
            {
                if (newIns)
                {
                    _current.AutobusID = getNextId(_current);
                }
                AppData.getContext().Autobus.AddOrUpdate(_current);
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
