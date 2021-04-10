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
    /// Логика взаимодействия для AddProductPage.xaml
    /// </summary>
    public partial class AddProductPage : Page
    {
        public AddProductPage()
        {
            InitializeComponent();
            txtIdProduct.Text = (AppData.Context.Product.ToList().Select(i => i.ID).Max() + 1).ToString();

            cmbNameCategory.ItemsSource = AppData.Context.CategoryProduct.ToList();
            cmbNameCategory.DisplayMemberPath = "NameCategory";
            cmbNameCategory.SelectedIndex = 0;

            cmbUnit.ItemsSource = AppData.Context.Unit.ToList();
            cmbUnit.DisplayMemberPath = "NameUnit";
            cmbUnit.SelectedIndex = 0;
        }

        private void btnAddProduct_Click(object sender, RoutedEventArgs e)
        {
            EF.Product product = new EF.Product();

            if (int.TryParse(txtIdProduct.Text, out int val))
            {
                int idNewProduct = Int32.Parse(txtIdProduct.Text);
                if (AppData.Context.Product.Where(i => i.ID == idNewProduct).FirstOrDefault() == null)
                {
                    product.ID = Int32.Parse(txtIdProduct.Text.Trim());
                }
                else
                {
                    MessageBox.Show("Артикул занят", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            }
            else
            {
                MessageBox.Show("Недопустимый артикул", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            product.NameProduct = txtNameProduct.Text;
            product.IDCategory = cmbNameCategory.SelectedIndex + 1;
            product.IDUnit = cmbUnit.SelectedIndex + 1;
            product.Description = txtDescription.Text;


            var res = MessageBox.Show("Подтвердите добавление товара", "Подтверждение добавления", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (res == MessageBoxResult.Yes)
            {
                AppData.Context.Product.Add(product);
                AppData.Context.SaveChanges();
                MessageBox.Show("Товар успешно добавлен", "", MessageBoxButton.OK, MessageBoxImage.Information);

                ClassHelper.NavigateClass.MainFrame.GoBack();
            }
        }
    }
}
