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

namespace WpfApp10.ToolsForms
{
    /// <summary>
    /// Логика взаимодействия для AddProductWindow.xaml
    /// </summary>
    public partial class AddProductWindow : Window
    {
        public AddProductWindow()
        {
            InitializeComponent();
        }

        private void btnAddProduct_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DB.MyContext myContext = new DB.MyContext();
                DB.Product newProduct = new DB.Product()
                { 
                    ProductName = tbProductName.Text,
                    Artikul = tbArtikul.Text,
                    Description = tbDescription.Text,
                    Manufacture = tbManufacture.Text,
                    Price = Convert.ToDouble(tbPrice.Text),
                    Sale = Convert.ToDouble(tbSale.Text),
                };
                try
                {
                    myContext.products.Add(newProduct);
                    myContext.SaveChanges();
                    MessageBox.Show("Product was added");
                }
                catch 
                { MessageBox.Show("Product wasnt added"); }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            UsersForms.AdminWindow adminWindow = new UsersForms.AdminWindow();
            adminWindow.Show();
            Close();
        }
    }
}
