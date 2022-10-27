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

namespace WpfVideoMediaElement
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            UrlTextBox.Text = @"http://v-platform-video-gz-test.cdn.huya.com/leaf/1048585/1099511667844/2222653/2689_936b91657a34bb471eb09c128aa777f2_264_1080.mp4";
        }

        private void VideoElement_MediaEnded(object sender, RoutedEventArgs e)
        {
           
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            var text = UrlTextBox.Text;
            if(string.IsNullOrEmpty(text))
                return;
            VideoElement.Source = new Uri(text);
            VideoElement.Play();
        }

        private void ButtonBase1_OnClick(object sender, RoutedEventArgs e)
        {
            VideoElement.Stop();
            var text = UrlTextBox.Text;
            if (string.IsNullOrEmpty(text))
                return;
            VideoElement.Source = new Uri(text);
            VideoElement.Play();
        }

        private void ButtonBase2_OnClick(object sender, RoutedEventArgs e)
        {
            VideoElement.Stop();
        }
    }
}
