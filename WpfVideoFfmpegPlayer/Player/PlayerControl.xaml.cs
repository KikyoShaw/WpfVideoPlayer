using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace WpfVideoFfmpegPlayer.Player
{
    /// <summary>
    /// Interaction logic for PlayerControl.xaml
    /// </summary>
    public partial class PlayerControl : UserControl
    {
        public PlayerControl()
        {
            this.Dispatcher.BeginInvoke((Action)delegate {
                InitializeComponent();

                //必须在为播放器指定uri之前设置FFmpegDirectory的值
                //它引用一些依赖的.dll和.exe文件，该文件在../bin/DLL/中
                Unosquare.FFME.MediaElement.FFmpegDirectory = Directory.GetCurrentDirectory() + "\\DLL\\";

                //当视频播放器的属性发生改变时，如开始播放，停止播放
                //同时修改由播放状态决定的属性值
                // Media.PropertyChanged += Media_PropertyChanged;

                this.Unloaded += PlayerControl_Unloaded;
            });
        }

        private void PlayerControl_Unloaded(object sender, RoutedEventArgs e)
        {
            Media?.Close();
        }

        public void Play(string url)
        {
            if (Media == null)
                return;

            try
            {
                if (!string.IsNullOrEmpty(url))
                {
                    if (Media.IsPlaying)
                        Media.Stop();
                    //指定播放路径
                    Media.Source = new Uri(url);
                    var aaa = Media.IsPlaying;
                    //开始播放
                    Media.Play();
                    var bbb = Media.IsPlaying;
                }
            }
            catch /*(Exception e)*/
            {
                //Console.WriteLine(e);
                //throw;
            }
        }
    }
}
