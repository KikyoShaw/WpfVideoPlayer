using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace WpfVideoMediaPlayer
{
    /// <summary>
    /// Interaction logic for VideoRender.xaml
    /// </summary>
    public partial class VideoRender : UserControl
    {
        private readonly MediaPlayer _player;
        public VideoRender()
        {
            InitializeComponent();
            _player = new MediaPlayer();
            //player.Open(new Uri(@"test.mp4", UriKind.Relative));
            //player.Play();
            _player.Volume = 0;
        }

        public void Play(string text)
        {
            _player?.Open(new Uri(text));
            _player?.Play();
            this.InvalidateVisual();
        }

        public void Pause()
        {
            _player?.Pause();
        }

        public void Stop()
        {
            _player?.Stop();
        }

        public void Restart(string text)
        {
            _player?.Stop();
            _player?.Open(new Uri(text));
            _player?.Play();
            this.InvalidateVisual();
        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            base.OnRender(drawingContext);
            if (_player != null && _player.Source != null)
            {
                //var height = _player.NaturalVideoHeight * this.ActualWidth / _player.NaturalVideoWidth;
                drawingContext.DrawVideo(_player, new Rect(0,0, 500, 700/*this.ActualWidth, height*/));
            }
        }
    }
}
