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
    /// Логика взаимодействия для ItineraryEdit.xaml
    /// </summary>
    public partial class ItineraryEdit : Page
    {
        Itinary _current;
        public ItineraryEdit(Itinary itinary)
        {
            InitializeComponent();
            _current = itinary;
            AppData.dockPanel.Children.Clear();
        }
    }
}
