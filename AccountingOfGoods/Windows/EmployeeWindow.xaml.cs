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
using AccountingOfGoods.Pages;

namespace AccountingOfGoods.Windows
{
    /// <summary>
    /// Логика взаимодействия для EmployeeWindow.xaml
    /// </summary>
    public partial class EmployeeWindow : Window
    {
        
        public EmployeeWindow()
        {
            InitializeComponent();

            ClassHelper.NavigateClass.MainFrame = frame;
            
                frame.Navigate(new ProductListPage());
        }

        private void btnProductInStock_Click(object sender, RoutedEventArgs e)
        {
            frame.Navigate(new ProductInStockPage()); 
        }

        private void btnProduct_Click(object sender, RoutedEventArgs e)
        {
            frame.Navigate(new ProductListPage());
        }

        private void btnSupport_Click(object sender, RoutedEventArgs e)
        {
            frame.Navigate(new SupportPage());
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            if (frame.CanGoBack)
            {
                frame.GoBack();
            }
        }
    }
}
