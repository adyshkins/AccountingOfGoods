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
using AccountingOfGoods.EF;

namespace AccountingOfGoods.Pages
{
    /// <summary>
    /// Логика взаимодействия для ProductInStockPage.xaml
    /// </summary>
    public partial class ProductInStockPage : Page
    {
        public ProductInStockPage()
        {
            InitializeComponent();

            
        }

        private void btnGenerateReport_Click(object sender, RoutedEventArgs e)
        {
            List<ChangeQuantityProduct> listProduct = new List<ChangeQuantityProduct>();

            if (dpStartDate.SelectedDate != null && dpEndtDate.SelectedDate != null)
            {
                listProduct = AppData.Context.ChangeQuantityProduct.
                Where(i => i.DateChange >= dpStartDate.SelectedDate && i.DateChange <= dpEndtDate.SelectedDate).
                ToList();
                lvProductInStock.ItemsSource = listProduct;
            }
            else
            {
                listProduct = AppData.Context.ChangeQuantityProduct.ToList();
                var resultMessage = MessageBox.Show("Сформировать отчет за все время?", "", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (resultMessage == MessageBoxResult.Yes)
                {
                    lvProductInStock.ItemsSource = listProduct;
                }

            }

        }

        private void btnPrint_Click(object sender, RoutedEventArgs e) // печать листа
        {
            PrintDialog printDialog = new PrintDialog();
            if (printDialog.ShowDialog() == true)
            {
                printDialog.PrintVisual(lvProductInStock, $"Отчет движения товаров на {DateTime.UtcNow}");
            }
        }
    }
}
