using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace MallMapKiosk.Common.Utilities
{
    public sealed class AudioController
    {
        private static readonly MediaPlayer player = new MediaPlayer();

        public static void PlaySound()
        {
            var path = FileRetriever.GetFile("assets\\", "background.wav");

            player.Open(new Uri(path, UriKind.Relative));
            player.Volume = 3.0;

            player.MediaEnded += (s, e) =>
            {
                player.Position = TimeSpan.Zero;
                player.Play();
            };

            player.Play();
        }
    }
}
