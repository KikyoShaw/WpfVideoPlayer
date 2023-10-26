using System.Windows;

namespace WpfVideoFfmpegPlayer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            UrlTextBox.Text = @"https://v2.kwaicdn.com/upic/2022/09/30/12/BMjAyMjA5MzAxMjEyNDJfMjIxMjQ4ODIyNV84NTI5MzA3Mzg3MV8yXzM=_hd15_B2e9c58667813baf16b5acf3ac0f2eea1.mp4?pkey=AAXhc_e-EnF4H0GiBMdZePwU8P-6KUrYEQck8gYFHJN3dWHTX9e53UpCqaHMHGw5VqgL7mm3zFIifaWb5GnSS_8H3vC-7y2fS7gA08Qr-_q-nXpgJBbJchSZQ4CukMdm6Ok&tag=1-1666689207-unknown-0-3wkszwowoe-97998829cd9c57c6&clientCacheKey=3xgtkejfdmn7a5k_hd15.mp4&di=3afe9535&bp=10004&tt=hd15&ss=vp";
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //var sourceStr = @"https://v2.kwaicdn.com/upic/2022/09/30/12/BMjAyMjA5MzAxMjEyNDJfMjIxMjQ4ODIyNV84NTI5MzA3Mzg3MV8yXzM=_hd15_B2e9c58667813baf16b5acf3ac0f2eea1.mp4?pkey=AAXhc_e-EnF4H0GiBMdZePwU8P-6KUrYEQck8gYFHJN3dWHTX9e53UpCqaHMHGw5VqgL7mm3zFIifaWb5GnSS_8H3vC-7y2fS7gA08Qr-_q-nXpgJBbJchSZQ4CukMdm6Ok&tag=1-1666689207-unknown-0-3wkszwowoe-97998829cd9c57c6&clientCacheKey=3xgtkejfdmn7a5k_hd15.mp4&di=3afe9535&bp=10004&tt=hd15&ss=vp";
            //this.player1.Play(sourceStr);
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            var urlPath = UrlTextBox?.Text;
            //var urlPath = @"E:\shaw\demo\WPF-demo\ImageFileType\ImageFileType\test-images\Gif\kumin.gif";
            //var urlPath = @"D:\WXWork\16888554\Cache\File\2022-08\1111.webp";
            this.player1.Play(urlPath);
        }

        private void ButtonBase1_OnClick(object sender, RoutedEventArgs e)
        {
        }
    }
}
