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

namespace AccountingOfGoods.Pages
{
    // <summary>
    // Логика взаимодействия для ProductListPage.xaml
    // </summary>
    public partial class ProductListPage : Page
    {
        public ProductListPage()
        {
            InitializeComponent();
        }

        private void btnAddProduct_Click(object sender, RoutedEventArgs e)
        {
            NavigateClass.MainFrame.Navigate(new AddProductPage());
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
    }
}
