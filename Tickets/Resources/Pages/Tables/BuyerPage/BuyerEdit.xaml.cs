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

namespace Tickets.Resources.Pages.Tables.BuyerPage
{
    /// <summary>
    /// Логика взаимодействия для BuyerEdit.xaml
    /// </summary>
    public partial class BuyerEdit : Page
    {
        Buyer _current;
        public BuyerEdit(Buyer buyer)
        {
            InitializeComponent();
            _current = buyer;
            AppData.dockPanel.Children.Clear();
        }
    }
}
