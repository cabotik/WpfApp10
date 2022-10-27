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

namespace WpfApp10.UsersForms
{
    /// <summary>
    /// Логика взаимодействия для AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        public AdminWindow()
        {
            InitializeComponent();

            DB.User user = new DB.User();
            tbUserName.Text = user.Name;
            
        }

        private void btnAddProduct_Click(object sender, RoutedEventArgs e)
        {
            ToolsForms.AddProductWindow addProductWindow = new ToolsForms.AddProductWindow();
            addProductWindow.Show();
            Close();
        }

        private void btnChangeProduct_Click(object sender, RoutedEventArgs e)
        {
            ToolsForms.ChangeProductWindow changeProductWindow = new ToolsForms.ChangeProductWindow();
            changeProductWindow.Show();
            Close();
        }

        private void btnMakeAnOrder_Click(object sender, RoutedEventArgs e)
        {
            ToolsForms.MakeOrderWindow makeOrderWindow = new ToolsForms.MakeOrderWindow();
            makeOrderWindow.Show();
            Close();
        }

        private void btnChangeAnOrder_Click(object sender, RoutedEventArgs e)
        {
            ToolsForms.ChangeAnOrderWindow changeAnOrderWindow = new ToolsForms.ChangeAnOrderWindow();
            changeAnOrderWindow.Show();
            Close();
        }

        private void btnViewproductList_Click(object sender, RoutedEventArgs e)
        {
            ToolsForms.ProductListWindow productListWindow = new ToolsForms.ProductListWindow();
            productListWindow.Show();
            Close();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }
    }
}
