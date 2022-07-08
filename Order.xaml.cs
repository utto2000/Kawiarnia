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
        private int milk = 1;
        private int coffee= 1;

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
            var orders = (from o in kawiarniaEntities1.Orders
                          join c in kawiarniaEntities1.Customer
                          on o.CustromerId equals c.CustomerId
                          join cof in kawiarniaEntities1.Coffee
                          on o.CoffeeId equals cof.CoffeeId
                          join m in kawiarniaEntities1.Milk
                          on o.MilkId equals m.MilkId
                          select new
                          {
                            CustomerName = c.FirstName,
                            CoffeeName = cof.CoffeeName,
                            MilkName = m.MilkName,
                          }).ToList();


            this.gridLastOrder.ItemsSource = Enumerable.Reverse(orders);



        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            KawiarniaEntities1 kawiarniaEntities1 = new KawiarniaEntities1();
            var email = from em in kawiarniaEntities1.Customer where em.email == this.textBoxEmail.Text select em;
            foreach (var item in email)
            {
                var order = new Orders()
                {
                    CustromerId = item.CustomerId,
                    CoffeeId = coffee,
                    MilkId = milk,
                };
                kawiarniaEntities1.Orders.Add(order);
                

            }
            kawiarniaEntities1.SaveChanges();
        }

        private void RadioCowMilk_Checked(object sender, RoutedEventArgs e)
        {
            milk = 1;
        }

        private void radioGoatMilk_Checked(object sender, RoutedEventArgs e)
        {
            milk = 2;
        }

        private void radioSheepMilk_Checked(object sender, RoutedEventArgs e)
        {
            milk = 3;
        }

        private void radioArabica_Checked(object sender, RoutedEventArgs e)
        {
            coffee = 1;
        }

        private void radioRobusta_Checked(object sender, RoutedEventArgs e)
        {
            coffee = 2;
        }

        private void radioLatte_Checked(object sender, RoutedEventArgs e)
        {
            coffee = 3;
        }
    }
}
