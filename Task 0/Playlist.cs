using System.Collections.Generic;

namespace Task_0
{
    public abstract class Playlist
    {
        private List<MediaFile> playlist;

        protected Playlist(List<MediaFile> playlist)
        {
            this.playlist = playlist;
        }

        public void Play()
        {
            
        }
    }
}