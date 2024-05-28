using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Tickets.Resources.LibsAndDitcionary;
using Tickets.Resources.Windows;

namespace Tickets.Resources.LibsAndDictionary
{
    public static class AppData
    {
        //Общие данные
        public static User authUser { get; set; }
        public static MainWin mainWin { get; set; }
        public static Frame mFrame { get; set; }
        public static StackPanel dockPanel { get; set; }

        //Получение контекста базы данных
        private static SellTicketsDBEntities _context;
        public static SellTicketsDBEntities getContext() { 
            if (_context == null) _context = new SellTicketsDBEntities();
             return _context;
        }

        //Общие методы


        public delegate void SimpleMethod();
        public static void AddDock<T>(DataGrid dataGrid, Action addNavigationAction, SimpleMethod delItems) where T : class
        {
            // Очистите панель от предыдущих кнопок, если необходимо
            dockPanel.Children.Clear();

            Button btn_del = new Button();
            Button btn_add = new Button();

            btn_add.Content = "Добавить";
            btn_del.Content = "Удалить";

            btn_del.Click += (sender, e) => delItems();
            btn_add.Click += (sender, e) => addNavigationAction();

            dockPanel.Children.Add(btn_add);
            dockPanel.Children.Add(btn_del);
        }
        

    }

}
