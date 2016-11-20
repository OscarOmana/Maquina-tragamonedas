using System;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using System.Windows.Media.Animation;

// peoyecto WPF tragamonedas 
namespace Tragamonedas
{
    public partial class MainWindow : Window
    {
        int ficha1, ficha2, ficha3;
        DispatcherTimer temp;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnPlay_Click_1(object sender, RoutedEventArgs e)
        {
            temp = new DispatcherTimer();
            temp.Interval = TimeSpan.FromMilliseconds(1600);
            temp.Tick += Temp_Tick;
            temp.Start();

            Storyboard sb = (Storyboard)FindResource("Storyboard1");
            sb.Begin();
        }

        private void Temp_Tick(object sender, EventArgs e)
        {
            Random r = new Random();
            BitmapImage[] pictures = new BitmapImage[6];
            pictures[0] = new BitmapImage(uriSource: new Uri(@"pack://application:,,,/Tragamonedas;component/1.jpg", UriKind.RelativeOrAbsolute));
            pictures[1] = new BitmapImage(uriSource: new Uri(@"pack://application:,,,/Tragamonedas;component/2.jpg", UriKind.RelativeOrAbsolute));
            pictures[2] = new BitmapImage(uriSource: new Uri(@"pack://application:,,,/Tragamonedas;component/3.jpg", UriKind.RelativeOrAbsolute));
            pictures[3] = new BitmapImage(uriSource: new Uri(@"pack://application:,,,/Tragamonedas;component/4.jpg", UriKind.RelativeOrAbsolute));
            pictures[4] = new BitmapImage(uriSource: new Uri(@"pack://application:,,,/Tragamonedas;component/5.jpg", UriKind.RelativeOrAbsolute));
            pictures[5] = new BitmapImage(uriSource: new Uri(@"pack://application:,,,/Tragamonedas;component/6.jpg", UriKind.RelativeOrAbsolute));
            ficha1 = r.Next(1, 6);
            ficha2 = r.Next(1, 6);
            ficha3 = r.Next(1, 6);
            image1.Source = pictures[ficha1];
            image2.Source = pictures[ficha2];
            image3.Source = pictures[ficha3];


            if (ficha1 == ficha2 && ficha2 == ficha3)
            {
                Storyboard gn = (Storyboard)FindResource("Storyboard2");
                gn.Begin();
            }
            else
            {
                Storyboard pd = (Storyboard)FindResource("Storyboard3");
                pd.Begin();
            }

            temp.Stop();
        }
    }
}
