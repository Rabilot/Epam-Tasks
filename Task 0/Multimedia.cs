using System;
using System.Collections.Generic;
using Task_0.Interfaces;

namespace Task_0
{
    public class Multimedia : IMultimedia
    {
        private List<MediaFile> MediaFiles = new List<MediaFile>();
        private List<IPlaylist> Playlists = new List<IPlaylist>();
        

        public Multimedia GetMultimediaFromDirectory(string path)
        {
            return new Multimedia();
        }

        public void AddMediaFile(MediaFile mediaFile)
        {
            
        }
        
        public void RemoveMediaFile(MediaFile mediaFile)
        {
            
        }

        public void AddPlayList(Playlist playlist)
        {
            
        }

        public void RemovePlayList(Playlist playlist)
        {
            
        }

        public MediaFile FindMediaFile(string name)
        {
            return null;
            if (MediaFiles[0] is Photo) ;
        }
        
        


        public override string ToString()
        {
            return base.ToString();
        }
    }
}