using System.Collections.Generic;

namespace Task_0
{
    public class Player
    {
        public void Play(Playlist playlist)
        {
              playlist.Play();
        }

        public void Play(MediaFile mediaFile)
        {
            mediaFile.Play();
        }
    }
}