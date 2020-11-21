using System;

namespace Task_0
{
    public class Music : MediaFile
    {
        public int Duration;
        public int FlowRate;
        public string Genres;
        public string Performer;
        public string Album;
        
        public Music GetInfoByMusic(string[] infoFromLine)
        {
          return new Music();
        }
    }
}