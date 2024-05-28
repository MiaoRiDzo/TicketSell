﻿using System;
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
    /// Логика взаимодействия для BuyerView.xaml
    /// </summary>
    public partial class BuyerView : Page
    {
        public BuyerView()
        {
            InitializeComponent();
            dg_buyer.ItemsSource = AppData.getContext().Buyer.ToList();
            
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            AppData.AddDock<Buyer>(dg_buyer, () => AppData.mFrame.Navigate(new BuyerPage.BuyerEdit(null)));
        }
    }
}
