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

                image.MouseLeftButtonDown += shape_MouseLeftButtonDown;
                image.MouseMove += shape_MouseMove;
                image.MouseLeftButtonUp += shape_MouseLeftButtonUp;

                image.Width = rong;
                image.Height = cao;

                Canvas.SetTop(image, top);
                Canvas.SetLeft(image, left);

                khungve.Children.Add(image);
            }
            else if (feSource.Name == "btnHCN")
            {
                Rectangle redRectangle = new Rectangle();

                redRectangle.MouseLeftButtonDown += shape_MouseLeftButtonDown;
                redRectangle.MouseMove += shape_MouseMove;
                redRectangle.MouseLeftButtonUp += shape_MouseLeftButtonUp;

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

                ellipse.MouseLeftButtonDown += shape_MouseLeftButtonDown;
                ellipse.MouseMove += shape_MouseMove;
                ellipse.MouseLeftButtonUp += shape_MouseLeftButtonUp;

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

        bool captured = false;
        double x_shape, y_shape, x_start, y_start;
        UIElement source = null;

        private void shape_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            source = (UIElement)sender;
            Mouse.Capture(source);
            captured = true;
            x_shape = Canvas.GetLeft(source);
            x_start = e.GetPosition(khungve).X;
            y_shape = Canvas.GetTop(source);
            y_start = e.GetPosition(khungve).Y;
        }

        private void shape_MouseMove(object sender, MouseEventArgs e)
        {
            if (captured)
            {
                double x = e.GetPosition(khungve).X;
                double y = e.GetPosition(khungve).Y;

                x_shape += x - x_start;
                Canvas.SetLeft(source, x_shape);
                y_shape += y - y_start;
                Canvas.SetTop(source, y_shape);
                x_start = x;
                y_start = y;
            }
        }

        private void shape_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Mouse.Capture(null);
            captured = false;
        }
    }
}
