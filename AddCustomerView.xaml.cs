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
using System.Data.Sql;
namespace Kawiarnia
{
    /// <summary>
    /// Logika interakcji dla klasy AddCustomerView.xaml
    /// </summary>
    public partial class AddCustomerView : Window
    {
        public AddCustomerView()
        {
            InitializeComponent();
        }

        private void btn_AddCutomerToDataBase_Click(object sender, RoutedEventArgs e)
        {
            var context = new KawiarniaEntities1();
            
            var customer = new Customer()
            {
                FirstName  = this.Firstname.Text,
                email = this.Email.Text,
                Age = Int32.Parse(this.Age.Text),
            };
            context.Customer.Add(customer);
            context.SaveChanges();
        }

        private void BackToMenu(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            this.Visibility = Visibility.Hidden;
            mainWindow.Show();
        }

       

    }
}
