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
using AccountingOfGoods.Windows;
using AccountingOfGoods.Pages;
using AccountingOfGoods.EF;

namespace AccountingOfGoods
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class AuthorizationWindow : Window
    {
        
        public AuthorizationWindow()
        {
            InitializeComponent();
        }

        private void btnSignIN_Click(object sender, RoutedEventArgs e)
        {
            var activUser = AppData.Context.User.ToList().Where(i => i.Login == txtLogin.Text && i.Password == txtPassword.Password).FirstOrDefault();

            if (activUser != null)
            {
                ClassHelper.UserData.activUser = activUser;

                EmployeeWindow employeeWindow = new EmployeeWindow();
                Hide();
                employeeWindow.ShowDialog();
                Show();
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
        }

        private void TextBlock_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            SupportMessageWindow supportMessageWindow = new SupportMessageWindow(); 
            Hide();
            supportMessageWindow.ShowDialog();
            Show();

        }
    }
}
