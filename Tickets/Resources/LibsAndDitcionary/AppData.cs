using System;
using System.Collections.Generic;
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
        //Получение контекста базы данных
        private static SellTicketsDBEntities _context;
        public static SellTicketsDBEntities getContext() { 
            if (_context == null) _context = new SellTicketsDBEntities();
             return _context;
        }

        //Общие методы
        public static void DeleteItems<T>(DataGrid dataGrid) where T : class
        {
            var removes = dataGrid.SelectedItems.Cast<T>().ToList();
            if (MessageBox.Show($"Вы точно хотите удалить следующие {removes.Count()} элементы?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    var context = AppData.getContext();
                    context.Set<T>();
                    context.SaveChanges();
                    MessageBox.Show("Данные удалены");
                    dataGrid.ItemsSource = context.Set<T>().ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
     
        }

        public static void AddDock<T>(DataGrid dataGrid, Action addNavigationAction) where T : class
        {
            // Очистите панель от предыдущих кнопок, если необходимо
            dockPanel.Children.Clear();

            Button btn_del = new Button();
            Button btn_add = new Button();

            btn_add.Content = "Добавить";
            btn_del.Content = "Удалить";

            btn_del.Click += (sender, e) => DeleteItems<T>(dataGrid);
            btn_add.Click += (sender, e) => addNavigationAction();

            dockPanel.Children.Add(btn_add);
            dockPanel.Children.Add(btn_del);
        }
        //Общие данные
        public static User authUser {  get; set; }
        public static MainWin mainWin { get; set; }
        public static Frame mFrame {  get; set; }
        public static StackPanel dockPanel { get; set; }
    }
}
