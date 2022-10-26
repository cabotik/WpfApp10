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
    /// Логика взаимодействия для ChangeProductWindow.xaml
    /// </summary>
    public partial class ChangeProductWindow : Window
    {
        public string[] ImagePath = new string[]
        { 
            "MyImage/kraken.png", "MyImage/coin.png"
        };
        public string[] category = new string[]
        {
                "product", "tresh"
        };
        public ChangeProductWindow()
        {
            InitializeComponent();
            cbCategory.ItemsSource = category;
            cbImage.ItemsSource = ImagePath;

        }

        private void btnFoundArtikul_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DB.MyContext myContext = new DB.MyContext();
                var pr = myContext.products.SingleOrDefault(x => x.Artikul == tbArtikul.Text);
                if (pr != null)
                {
                    tbProductName.Text = pr.ProductName.ToString();
                    tbDescription.Text = pr.Description.ToString();
                    tbManufacture.Text = pr.Manufacture.ToString();
                    tbPrice.Text = pr.Price.ToString();
                    tbSale.Text = pr.Sale.ToString();
                    var unitOnStorage = myContext.storages.Where(x =>x.ProductId == pr.ProductId);
                    if (unitOnStorage.Count() > 0)
                    {
                        tbUnitsOnStorage.Text = unitOnStorage.Sum(x => x.Count).ToString();
                    }
                    else
                    { MessageBox.Show("product wasnt deliver on storage"); }    
                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
        }

        private void btnChangeProduct_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DB.MyContext myContext = new DB.MyContext();
                var pr = myContext.products.SingleOrDefault(x => x.Artikul == tbArtikul.Text);
                if (pr != null)
                {
                    pr.ProductName = tbProductName.Text;
                    pr.Description = tbDescription.Text;
                    pr.Manufacture = tbManufacture.Text;
                    pr.Price = Convert.ToDouble(tbPrice.Text);
                    pr.Sale = Convert.ToDouble(tbSale.Text);
                    if (tbCategory.Text != null)
                    {
                        pr.Catrgory = cbCategory.ItemsSource.ToString();
                    }
                    if (tbImage.Text != null)
                    {
                        pr.ImagePath = cbImage.ItemsSource.ToString();
                    }
                    myContext.products.Update(pr);
                    myContext.SaveChanges();
                    MessageBox.Show("product was changed");
                }
                else { MessageBox.Show("product wasnt changed"); }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }

        }
        private void btnAaddDeliver_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DB.MyContext myContext = new DB.MyContext();
                var pr = myContext.products.SingleOrDefault(x => x.Artikul == tbArtikul.Text);
                if (pr != null)
                {
                    var delivery = new DB.Storage();
                    delivery.ProductId = pr.ProductId;
                    delivery.Count = Convert.ToInt32(tbAddDeliver.Text);
                    myContext.storages.Add(delivery);
                    myContext.SaveChanges();
                    MessageBox.Show("Units was added");
                }
                else { MessageBox.Show("units wasnt added "); }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }

        }
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DB.MyContext myContext = new DB.MyContext();
                var pr = myContext.products.SingleOrDefault(x => x.Artikul == tbArtikul.Text);
                if (pr != null)
                {
                    myContext.products.Remove(pr);
                    myContext.SaveChanges();
                    MessageBox.Show("product was delete");
                }
                else { MessageBox.Show("product wasnt delete"); }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }

        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
