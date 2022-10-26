using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
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
using Brushes = System.Drawing.Brushes;

namespace WpfApp10
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string text;
        private string textOne;
        private string textTwo;
        private BitmapImage ImageCreater(int Width, int Height)
        {
            Random random = new Random();
            Bitmap result = new Bitmap(Width, Height);
            int Xpos = random.Next(10, Width -20);
            int Ypos = random.Next(5, Height -10 );
            int XposOne = random.Next(5, Width -21);
            int YposOne = random.Next(10, Height - 14);

            System.Drawing.Brush[] colors = {Brushes.DarkOliveGreen, Brushes.DarkGoldenrod, Brushes.Bisque };
            textOne = string.Empty;
            string symbols = "1234567890qazwsxedcrfvtgbyhnujmikolpQWERTYUIOPASDFGHJKLZXCVBNM";
            for (int i = 0; i < 2; i++)
                textOne += symbols[random.Next(symbols.Length)];
            textTwo = string.Empty;
            for (int i = 0; i < 2; i++)
                textTwo += symbols[random.Next(symbols.Length)];

            Graphics g = Graphics.FromImage(result);

            g.DrawString(textOne, new Font("Arial", 10),
                colors[random.Next(colors.Length)],
                new PointF(Xpos, Ypos));
            g.DrawString(textTwo, new Font("Arial", 10),
               colors[random.Next(colors.Length)],
               new PointF(XposOne, YposOne));

            text = textOne + textTwo;

            g.DrawLine(Pens.BlueViolet,
                new PointF(0,0),
                new PointF(Width - 1, Height - 1));
            g.DrawLine(Pens.OrangeRed,
               new PointF(0, Height - 1),
               new PointF(Width - 1, 0));

            for (int i = 0; i < Width; ++i)
                for (int j = 0; j < Height; ++j)
                    if (random.Next() % 20 == 0)
                        result.SetPixel(i, j, System.Drawing.Color.White);
            return Converter(result);

        }

        private BitmapImage Converter(Bitmap result)
        {
            MemoryStream ms = new MemoryStream();
            BitmapImage image = new BitmapImage();
            result.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            image.BeginInit();
            ms.Seek(0, SeekOrigin.Begin);
            image.StreamSource = ms;
            image.EndInit();
            return image;
        }

        public MainWindow()
        {
            InitializeComponent();
            spCaptcha.Visibility = Visibility.Hidden;
        }

        private void btnInput_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbLogin.Text ))
            {
                MessageBox.Show("Enter login");
                return;
            }
            if (string.IsNullOrWhiteSpace(pbPassword.Password))
            {
                MessageBox.Show("Enter password");
                return;
            }
            Authorization();
        }

        private void Authorization()
        {
            try
            {
                DB.MyContext myContext = new DB.MyContext();
                if (myContext.users.Any(x => x.Login == tbLogin.Text && x.Password == pbPassword.Password))
                {
                    var user = myContext.users.SingleOrDefault(x => x.Login == tbLogin.Text && x.Password == pbPassword.Password);
                   

                    switch (user.Account)
                    {
                        case "admin":
                            MessageBox.Show($"{user.Name}-добро пожаловать в систему");
                            UsersForms.AdminWindow adminWindow = new UsersForms.AdminWindow();
                            adminWindow.Show();
                            Close();
                            break;

                        case "client":
                            MessageBox.Show($"{user.Name}-добро пожаловать в систему");
                            UsersForms.ClientWindow clientWindow = new UsersForms.ClientWindow();
                            clientWindow.Show();
                            Close();
                            break;

                        case "maneger":
                            MessageBox.Show($"{user.Name}-добро пожаловать в систему");
                            UsersForms.ManagerWindow managerWindow = new UsersForms.ManagerWindow();
                            managerWindow.Show();
                            Close();
                            break;
                    }
                }
                else
                {
                    MessageBox.Show("Пользователь не найден");
                    return;
                }

            }
            catch(Exception ex)
            { MessageBox.Show(ex.Message); }
        }

        private void IncorrectAutho()
        {
            if (tbCaptcha.Text == string.Empty)
            {
                ImageCaptcha.Source = ImageCreater(Convert.ToInt32(ImageCaptcha.Width), Convert.ToInt32(ImageCaptcha.Height));
                return;
            }
            if (tbCaptcha.Text != text)
            {
                MessageBox.Show("Incorrexr captcha. You will blocked for 10 second");
                for (int i = 10; i > 0; i--)
                {
                    this.Title = $"block fot {i} seconds";
                    Thread.Sleep(1000);
                }
                Title = "Authorization Window";
                tbCaptcha.Clear();
                return;
            }
            if (tbCaptcha.Text == text)
            {
                Authorization();
            }
        }

        private void btnInputWithoutAutho_Click(object sender, RoutedEventArgs e)
        {
            ToolsForms.ProductListWindow productListWindow = new ToolsForms.ProductListWindow();
            productListWindow.Show();
            Close();
        }

        private void btnRefreah_Click(object sender, RoutedEventArgs e)
        {
            ImageCaptcha.Source = ImageCreater(Convert.ToInt32(ImageCaptcha.Width), Convert.ToInt32(ImageCaptcha.Height));
           
        }
    }
}
