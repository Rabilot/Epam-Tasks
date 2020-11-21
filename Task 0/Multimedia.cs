using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace Task_0
{
    public class Multimedia
    {
        public List<Music> MusicList = new List<Music>();
        public List<Photo> PhotoList = new List<Photo>();
        public List<VideoFile> VideoList = new List<VideoFile>();
        
        
        
        public Multimedia GetMultimediaFromFile(string path)
        {
            return new Multimedia();
        }

        public void AddMultimedia(Multimedia multimedia)
        {
        }
    }
}