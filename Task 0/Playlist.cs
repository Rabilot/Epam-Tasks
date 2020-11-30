using System.Collections.Generic;
using Task_0.Interfaces;

namespace Task_0
{
    public abstract class Playlist : IPlay
    {
        private List<MediaFile> playList = new List<MediaFile>();
        

        public void AddMediaFile(MediaFile mediaFile)
        {
            
        }

        public void RemoveMediaFile(MediaFile mediaFile)
        {
            
        }

        public MediaFile FindMediaFile(string name)
        {
            return null;
        }

        public void Play()
        {
            
        }
    }
}