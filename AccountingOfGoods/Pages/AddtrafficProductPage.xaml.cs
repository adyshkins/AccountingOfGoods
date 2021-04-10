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

            txtCountProduct.BorderBrush = new SolidColorBrush() { Color = (Color)(ColorConverter.ConvertFromString("#5F3504")) };
            txtCountProduct.BorderThickness = new Thickness(0.5);

            // проверка на корректно введенные значения и пустые поля
            if (int.TryParse(txtInStock.Text, out val)  && int.TryParse(txtCountProduct.Text, out val) || txtCountProduct.Text == string.Empty || txtInStock.Text == string.Empty)
            {

                if (int.TryParse(txtInStock.Text, out val))
                {
                    num1 = Int32.Parse(txtInStock.Text); // остаток на складе на момент начала движения товара
                }
                               

                if (int.TryParse(txtCountProduct.Text, out val))
                {
                    num2 = Int32.Parse(txtCountProduct.Text); // количество товара для перемещения
                }                

                if ( txtCountProduct.Text == string.Empty)
                {
                    num2 = 0;
                }

                if (cmbAction.SelectedIndex == 0)
                {
                    txtInStockNow.Text = $"{num1 + num2}"; // если операция приход то складываем то что сейчас на складе с тем что пришло
                }
                else
                {
                    int res = num1 - num2; // если операция расход, вычетаем из того что на складе

                    if (res < 0) // если после вычитания товара его количество отрицательное выдаем предупреждение
                    {
                        res = 0;
                        txtCountProduct.Foreground = Brushes.Red;
                        txtCountProduct.BorderThickness = new Thickness(2);
                        return;
                    }
                    else
                    {
                        txtInStockNow.Text = $"{num1 - num2}";
                    }
                }
            }           
            
        }

        private void btnAddProduct_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNumberDoc.Text)) // если пустой номер документа
            {
                txtNumberDoc.BorderBrush = Brushes.Red;
                txtNumberDoc.BorderThickness = new Thickness(2);
                return;
            }           

            if (string.IsNullOrWhiteSpace(txtCountProduct.Text)) // если пусто количество товаров
            {
                txtCountProduct.BorderBrush = Brushes.Red;
                txtCountProduct.BorderThickness = new Thickness(2);
                return;
            }

            if (cmbStorageOut.SelectedIndex == -1) // если не выбрана секция
            {
                cmbStorageOut.BorderBrush = Brushes.Red;
                return;
            }

            if (cmbAction.SelectedIndex == 1) // если выбран Расход товаров проверяем их остаток на складе
            {
                int num1 = Int32.Parse(txtInStock.Text);
                int num2 = Int32.Parse(txtCountProduct.Text);
                int res = num1 - num2;
                if (res < 0)
                {
                    MessageBox.Show("Товара на складе недостаточно для проведения данной операции","",MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            }
            

            product.InStock = Int32.Parse(txtInStockNow.Text);
            product.IDStorage = cmbStorageOut.SelectedIndex + 1;         

            ChangeQuantityProduct quantityProduct = new ChangeQuantityProduct();

            quantityProduct.DateChange = dpDateAction.DisplayDate;
            quantityProduct.IDProduct = product.ID;
            quantityProduct.IDTypeChange = cmbAction.SelectedIndex + 1;
            quantityProduct.NumberDoc = txtNumberDoc.Text;
            quantityProduct.Quantity = Int32.Parse(txtInStockNow.Text);
            quantityProduct.Note = txtNote.Text;
            quantityProduct.IDUser = ClassHelper.UserData.activUser.ID;
            quantityProduct.StartQuantity = Int32.Parse(txtInStock.Text);

            if (cmbAction.SelectedIndex == 0)
            {
                quantityProduct.InQuantity = Int32.Parse(txtCountProduct.Text);
                quantityProduct.OutQuantity = 0;
            }
            else
            {
                quantityProduct.OutQuantity = Int32.Parse(txtCountProduct.Text);
                quantityProduct.InQuantity = 0;
            }
            



            AppData.Context.ChangeQuantityProduct.Add(quantityProduct);
            AppData.Context.SaveChanges();

            MessageBox.Show("товар успешно перемещен", "", MessageBoxButton.OK, MessageBoxImage.Information);
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
