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
    /// Логика взаимодействия для AddtrafficProductPage.xaml
    /// </summary>
    public partial class AddtrafficProductPage : Page
    {
        List<string> actionList = new List<string>() {"Приход", "Расход"};

        private Product product;
        public AddtrafficProductPage()
        {
            InitializeComponent();
        }

        public AddtrafficProductPage(Product editProduct)
        {
            product = editProduct;
            InitializeComponent();

            actionList = AppData.Context.TypeChange.Select(i => i.NameTypeChange).ToList();
            cmbAction.ItemsSource = actionList;
            cmbAction.SelectedIndex = 0;

            cmbStorageOut.ItemsSource = AppData.Context.Storage.ToList();
            cmbStorageOut.DisplayMemberPath = "NumberStorage";

            if (editProduct.IDStorage == null)
            {
                cmbStorageOut.SelectedIndex = -1;
            }
            else
            {
                cmbStorageOut.SelectedIndex = editProduct.Storage.ID - 1;
            }

            txtIDProduct.Text = editProduct.ID.ToString();
            txtInStock.Text = editProduct.InStock.ToString();
            txtNameProduct.Text = editProduct.NameProduct;
            if (editProduct.IDStorage == null)
            {
                txtStorage.Text = "Не определено";
            }
            else
            {
                txtStorage.Text = editProduct.Storage.NumberStorage;
            }
            
            txtUnit.Text = editProduct.Unit.NameUnit;
            dpDateAction.SelectedDate = DateTime.Now;
            txtInStockNow.Text = txtInStock.Text;


        }

        private void txtCountProduct_TextChanged(object sender, TextChangedEventArgs e)
        {
            int val, num1 = 0, num2 = 0;            

            if (int.TryParse(txtInStock.Text, out val)  && int.TryParse(txtCountProduct.Text, out val) || txtCountProduct.Text == string.Empty || txtInStock.Text == string.Empty)
            {

                if (int.TryParse(txtInStock.Text, out val))
                {
                    num1 = Int32.Parse(txtInStock.Text);
                }
                               

                if (int.TryParse(txtCountProduct.Text, out val))
                {
                    num2 = Int32.Parse(txtCountProduct.Text);
                }                

                if ( txtCountProduct.Text == string.Empty)
                {
                    num2 = 0;
                }

                if (cmbAction.SelectedIndex == 0)
                {
                    txtInStockNow.Text = $"{num1 + num2}";
                }
                else
                {
                    int res = num1 - num2;
                    txtInStockNow.Text = $"{num1 - num2}";
                }
            }           
            
        }

        private void btnAddProduct_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNumberDoc.Text))
            {
                txtNumberDoc.BorderBrush = Brushes.Red;
                txtNumberDoc.BorderThickness = new Thickness(2);
                return;
            }           

            if (string.IsNullOrWhiteSpace(txtCountProduct.Text))
            {
                txtCountProduct.BorderBrush = Brushes.Red;
                txtCountProduct.BorderThickness = new Thickness(2);
                return;
            }

            if (cmbStorageOut.SelectedIndex == -1)
            {
                cmbStorageOut.BorderBrush = Brushes.Red;
                return;
            }
            
            product.InStock = Int32.Parse(txtInStockNow.Text);
            product.IDStorage = cmbStorageOut.SelectedIndex + 1;         

            ChangeQuantityProduct quantityProduct = new ChangeQuantityProduct();

            quantityProduct.DateChange = dpDateAction.DisplayDate;
            quantityProduct.IDProduct = product.ID;
            quantityProduct.IDTypeChange = cmbAction.SelectedIndex + 1;
            quantityProduct.NumberDoc = txtNumberDoc.Text;
            quantityProduct.Quantity = Int32.Parse(txtCountProduct.Text);
            quantityProduct.Description = txtDescription.Text;
            quantityProduct.IDUser = ClassHelper.UserData.activUser.ID;

            AppData.Context.ChangeQuantityProduct.Add(quantityProduct);
            AppData.Context.SaveChanges();

            MessageBox.Show("товар успешно перемещен");
            ClassHelper.NavigateClass.MainFrame.GoBack();
            
        }

        private void txtNumberDoc_GotFocus(object sender, RoutedEventArgs e)
        {
            txtNumberDoc.BorderBrush = new SolidColorBrush() { Color = (Color)(ColorConverter.ConvertFromString("#5F3504")) };
            txtNumberDoc.BorderThickness = new Thickness(0.5);
        }
       

        private void txtCountProduct_GotFocus(object sender, RoutedEventArgs e)
        {
            txtCountProduct.BorderBrush = new SolidColorBrush() { Color = (Color)(ColorConverter.ConvertFromString("#5F3504")) };
            txtCountProduct.BorderThickness = new Thickness(0.5);
        }

        private void cmbStorageOut_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            cmbStorageOut.BorderBrush = new SolidColorBrush() { Color = (Color)(ColorConverter.ConvertFromString("#5F3504")) };
        }
    }
}
