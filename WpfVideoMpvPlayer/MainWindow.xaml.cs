using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using Mpv.NET.Player;

namespace WpfVideoMpvPlayer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly MpvPlayer _player;

        public MainWindow()
        {
            InitializeComponent();
            _player = new MpvPlayer(PlayerHost.Handle)
            {
                Loop = true,
                Volume = 90
            };
            UrlTextBox.Text = @"https://v2.kwaicdn.com/upic/2022/09/30/12/BMjAyMjA5MzAxMjEyNDJfMjIxMjQ4ODIyNV84NTI5MzA3Mzg3MV8yXzM=_hd15_B2e9c58667813baf16b5acf3ac0f2eea1.mp4?pkey=AAXhc_e-EnF4H0GiBMdZePwU8P-6KUrYEQck8gYFHJN3dWHTX9e53UpCqaHMHGw5VqgL7mm3zFIifaWb5GnSS_8H3vC-7y2fS7gA08Qr-_q-nXpgJBbJchSZQ4CukMdm6Ok&tag=1-1666689207-unknown-0-3wkszwowoe-97998829cd9c57c6&clientCacheKey=3xgtkejfdmn7a5k_hd15.mp4&di=3afe9535&bp=10004&tt=hd15&ss=vp";
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            var text = UrlTextBox.Text;
            if (!string.IsNullOrEmpty(text))
            {
                if (_player.IsPlaying)
                    _player.Stop();
                _player.Load(text);
                _player.Resume();
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        private void Window_Closing(object? sender, CancelEventArgs e)
        {
            _player?.Dispose();
        }
    }
}
