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
                    context.Set<T>().RemoveRange(removes);
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

        //Общие данные
        public static User authUser {  get; set; }
        public static MainWin mainWin { get; set; }
        public static Frame mFrame {  get; set; }
        public static StackPanel dockPanel { get; set; }
    }
}
