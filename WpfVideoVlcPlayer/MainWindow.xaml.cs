using System;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using Vlc.DotNet.Wpf;

namespace WpfVideoPlayer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private VlcVideoSourceProvider sourceProvider;

        public MainWindow()
        {
            InitializeComponent();
            UrlTextBox.Text = @"https://v2.kwaicdn.com/upic/2022/09/30/12/BMjAyMjA5MzAxMjEyNDJfMjIxMjQ4ODIyNV84NTI5MzA3Mzg3MV8yXzM=_hd15_B2e9c58667813baf16b5acf3ac0f2eea1.mp4?pkey=AAXhc_e-EnF4H0GiBMdZePwU8P-6KUrYEQck8gYFHJN3dWHTX9e53UpCqaHMHGw5VqgL7mm3zFIifaWb5GnSS_8H3vC-7y2fS7gA08Qr-_q-nXpgJBbJchSZQ4CukMdm6Ok&tag=1-1666689207-unknown-0-3wkszwowoe-97998829cd9c57c6&clientCacheKey=3xgtkejfdmn7a5k_hd15.mp4&di=3afe9535&bp=10004&tt=hd15&ss=vp";
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            var urlPath = UrlTextBox?.Text;
            if (string.IsNullOrEmpty(urlPath))
                return;
            try
            {
                sourceProvider?.MediaPlayer.Play(new Uri(urlPath));
                this.VideoImage.Dispatcher.Invoke(() => {
                    this.VideoImage.SetBinding(System.Windows.Controls.Image.SourceProperty,
                        new Binding(nameof(VlcVideoSourceProvider.VideoSource)) { Source = sourceProvider });
                });
            }
            catch /*(Exception exception)*/
            {
                //Console.WriteLine(exception);
                //throw;
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //加载视频
            TaskFactory tf = new TaskFactory();
            Task taskTrack1 = tf.StartNew(LoadVideo);
        }

        private void LoadVideo()
        {
            try
            {
                var currentAssembly = Assembly.GetEntryAssembly();
                if(currentAssembly == null)
                    return;
                var currentDirectory = new FileInfo(currentAssembly.Location).DirectoryName;
                if(currentDirectory == null)
                    return;
                var libDirectory = new DirectoryInfo(Path.Combine(currentDirectory, "libvlc", IntPtr.Size == 4 ? "x86" : "x64"));
                sourceProvider = new VlcVideoSourceProvider(this.Dispatcher);
                sourceProvider.CreatePlayer(libDirectory);
            }
            catch /*(Exception e)*/
            {
                //Console.WriteLine(e);
                //throw;
            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            sourceProvider?.Dispose();
        }
    }
}
