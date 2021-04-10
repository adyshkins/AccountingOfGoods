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
using AccountingOfGoods.ClassHelper;
using AccountingOfGoods.EF;

namespace AccountingOfGoods.Pages
{
    // <summary>
    // Логика взаимодействия для ProductListPage.xaml
    // </summary>
    public partial class ProductListPage : Page
    {
        List<Product> products = new List<Product>();

        List<string> sortingList = new List<string>() {"Названию", "Остатку на складе", "Категории", "Секции хранения"};
        public ProductListPage()
        {
            InitializeComponent();

            cmbSorting.ItemsSource = sortingList;
            cmbSorting.SelectedIndex = 0;

            GetList();
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            GetList();
        }

        private void GetList()
        {
            products = AppData.Context.Product.ToList();

            products = products.OrderBy(i => i.NameProduct).ToList();

            if (txtSearchById.Text != "Поиск по артикулу")
            {
                products = products.Where(i => i.ID.ToString().ToLower().Contains(txtSearchById.Text.ToLower())).ToList();
            }

            if (txtSearchByName.Text != "Поиск по названию")
            {
                products = products.Where(i => i.NameProduct.ToLower().Contains(txtSearchByName.Text.ToLower())).ToList();
            }

            if (txtSearchByNum.Text != "Поиск по № секции")
            {
                products = products.Where(i => i.Storage.NumberStorage.ToLower().ToString().Contains(txtSearchByNum.Text.ToLower())).ToList();
            }

            switch (cmbSorting.SelectedIndex)
            {
                case 0:
                    products = products.OrderBy(i => i.NameProduct).ToList();
                    break;

                case 1:
                    products = products.OrderBy(i => i.InStock).ToList();
                    break;

                case 2:
                    products = products.OrderBy(i => i.IDCategory).ToList();
                    break;

                case 3:
                    products = products.OrderBy(i => i.IDStorage).ToList();
                    break;
                default:
                    break;
            }

            lvProduct.ItemsSource = products;
        }

        private void btnAddProduct_Click(object sender, RoutedEventArgs e)
        {
            NavigateClass.MainFrame.Navigate(new AddProductPage());
            GetList();
        }

        private void txtSearchById_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txtSearchById.Text == "Поиск по артикулу")
            {
                txtSearchById.Clear();
            }
        }

        private void txtSearchByName_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txtSearchByName.Text == "Поиск по названию")
            {
                txtSearchByName.Clear();
            }
        }

        private void txtSearchByNum_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txtSearchByNum.Text == "Поиск по № секции")
            {
                txtSearchByNum.Clear();
            }
        }

        private void txtSearchById_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearchById.Text))
            {
                txtSearchById.Text = "Поиск по артикулу";
            }
        }

        private void txtSearchByName_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearchByName.Text))
            {
                txtSearchByName.Text = "Поиск по названию";
            }
        }

        private void txtSearchByNum_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearchByNum.Text))
            {
                txtSearchByNum.Text = "Поиск по № секции";
            }
        }

        private void btnStockProduct_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button == null)
                return;
            var product = button.DataContext as Product; //получаем элемент

            NavigateClass.MainFrame.Navigate(new AddtrafficProductPage(product));

            GetList();
        }

        private void txtSearchById_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtSearchById.Text != "Поиск по артикулу")
            {
                GetList();
            }
        }

        private void txtSearchByName_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtSearchByName.Text != "Поиск по названию")
            {
                GetList();
            }
        }

        private void txtSearchByNum_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtSearchByNum.Text != "Поиск по № секции")
            {
                GetList();
            }
        }

        private void cmbSorting_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            GetList();
        }
    }
}
