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
using System.Windows.Shapes;

namespace Kawiarnia
{
    /// <summary>
    /// Logika interakcji dla klasy Order.xaml
    /// </summary>
    public partial class Order : Window
    {
        public Order()
        {
            InitializeComponent();
        }

        private void BackToMenu(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            this.Visibility = Visibility.Hidden;
            mainWindow.Show();

        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var context = new KawiarniaEntities1();
            Console.WriteLine(context.Orders.First());
           
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            InitializeComponent();
            KawiarniaEntities1 kawiarniaEntities1 = new KawiarniaEntities1();
            var orders = kawiarniaEntities1.Orders.Join(kawiarniaEntities1.Customer,
                o => o.CustromerId,
                c => c.CustomerId,
                (o, c) => new
                {
                    Firstname = c.FirstName,
                }
                ).Take(5);
            foreach (var order in orders)
            {
                Console.WriteLine(order.Firstname);
            }
            this.gridLastOrder.ItemsSource = orders.ToList();





        }

        
    }
}
