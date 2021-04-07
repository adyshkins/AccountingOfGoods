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

namespace AccountingOfGoods.Windows
{
    /// <summary>
    /// Логика взаимодействия для SupportMessageWindow.xaml
    /// </summary>
    public partial class SupportMessageWindow : Window
    {
        List<string> GoalOfRequestList = new List<string>() {"Выберите цель обращения","Цель 1", "Цель 2", "Цель 3" };
        public SupportMessageWindow()
        {
            InitializeComponent();
            cmbGoalOfRequest.ItemsSource = GoalOfRequestList;
            cmbGoalOfRequest.SelectedIndex = 0;

        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnSendMessage_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Сообщение отправлено");
            Close();
        }
    }
}
