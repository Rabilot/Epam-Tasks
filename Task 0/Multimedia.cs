using System;
using System.Collections.Generic;
using Task_0.Interfaces;

namespace Task_0
{
    public class Multimedia
    {
        private List<MediaFile> MediaFiles = new List<MediaFile>();
        //private List<Playlist> Playlists = new List<Playlist>();
        

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
        }
        
        


        public override string ToString()
        {
            return base.ToString();
        }
    }
}