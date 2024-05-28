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
    /// Логика взаимодействия для AutobusEdit.xaml
    /// </summary>
    public partial class AutobusEdit : Page
    {
        Autobus _current;
        public AutobusEdit(Autobus autobus)
        {
            InitializeComponent();
            AppData.dockPanel.Children.Clear();
            _current = autobus;
        }
    }
}
