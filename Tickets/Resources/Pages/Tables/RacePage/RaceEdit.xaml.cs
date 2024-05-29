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
    /// Логика взаимодействия для RaceEdit.xaml
    /// </summary>
    public partial class RaceEdit : Page
    {
        Race _current;
        public RaceEdit(Race race)
        {
            InitializeComponent();
            _current = race;
            AppData.dockPanel.Children.Clear();
        }
    }
}
