using System.Collections.Generic;
using Task_0.Interfaces;

namespace Task_0
{
    public class Player : IPlayer
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