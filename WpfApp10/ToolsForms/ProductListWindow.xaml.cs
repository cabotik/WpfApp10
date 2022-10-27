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
    /// Логика взаимодействия для ProductListWindow.xaml
    /// </summary>
    public partial class ProductListWindow : Window
    {
        public ProductListWindow()
        {
            InitializeComponent();
            this.Loaded += ProductListWindow_Loaded;
        }

        private void ProductListWindow_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                DB.Product product = new DB.Product();
                listproduct.Items.Add(product);
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
        }
    }
}
