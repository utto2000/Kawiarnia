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

namespace Kawiarnia
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OpenWindow(object sender, RoutedEventArgs e)
        {
            Order order = new Order();
            this.Visibility = Visibility.Hidden;
            order.Show();
            
        }

        private void OpenAddCustomerView(object sender, RoutedEventArgs e)
        {
            AddCustomerView addCustomerView = new AddCustomerView();
            this.Visibility = Visibility.Hidden;
            addCustomerView.Show();
        }
    }
}
