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

namespace bailam
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn(object sender, RoutedEventArgs e)
        {
            Random random = new Random();
            int top = random.Next(0, 300);
            int left = random.Next(0, 300);
            int rong = random.Next(50, 200);
            int cao = random.Next(50, 200);

            Color randomColor = Color.FromRgb((byte)random.Next(256), (byte)random.Next(256), (byte)random.Next(256));
            FrameworkElement feSource = e.Source as FrameworkElement;

            if (feSource.Name == "btnCho")
            {
                ImageSourceConverter imgsc = new ImageSourceConverter();
                ImageSource imageSource = (ImageSource)imgsc.ConvertFromString("Anh/cho.png");

                var image = new Image();
                image.Source = imageSource;

                image.Width = rong;
                image.Height = cao;

                Canvas.SetTop(image, top);
                Canvas.SetLeft(image, left);

                khungve.Children.Add(image);
            }
            else if (feSource.Name == "btnHCN")
            {
                Rectangle redRectangle = new Rectangle();

                redRectangle.Width = cao;
                redRectangle.Height = rong;

                Canvas.SetTop(redRectangle, top);
                Canvas.SetLeft(redRectangle, left);

                redRectangle.Fill = new SolidColorBrush(randomColor);
                redRectangle.Stroke = new SolidColorBrush(Colors.Black);
                redRectangle.StrokeThickness = 4;

                khungve.Children.Add(redRectangle);
            }
            else if (feSource.Name == "btnTron")
            {
                Ellipse ellipse = new Ellipse();

                ellipse.Width = rong;
                ellipse.Height = rong;

                Canvas.SetTop(ellipse, top);
                Canvas.SetLeft(ellipse, left);

                ellipse.Fill = new SolidColorBrush(randomColor);
                ellipse.Stroke = new SolidColorBrush(Colors.Black);
                ellipse.StrokeThickness = 4;

                khungve.Children.Add(ellipse);
            }
        }
    }
}
