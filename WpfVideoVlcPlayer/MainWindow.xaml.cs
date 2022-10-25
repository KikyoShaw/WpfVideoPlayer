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
            UrlTextBox.Text = @"https://v2l2j87anq2oou99rr2uk04ubrck78eyz.mobgslb.tbcache.com/v2.kwaicdn.com/upic/2022/09/30/12/BMjAyMjA5MzAxMjEyNDJfMjIxMjQ4ODIyNV84NTI5MzA3Mzg3MV8yXzM=_hd15_B2e9c58667813baf16b5acf3ac0f2eea1.mp4?pkey=AAUy6Ivcc6qSw-X4IOedF9s-9PvPohgSkIYeAoqTAetyknHsgtBO5tbMiQTODN2qZbIeSQ58RwpBBXkffjMN1QlVL7ghs7YwbMq8DpuHqexJ5S3B7VDpooEM3SUowYupJcE&tag=1-1666664696-unknown-0-uefdsqh8tx-95f1370695f6c57b&clientCacheKey=3xgtkejfdmn7a5k_hd15.mp4&di=3afe9535&bp=10004&tt=hd15&ss=vp&ali_redirect_ex_hot=66666800&ali_redirect_ex_beacon=1";
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
