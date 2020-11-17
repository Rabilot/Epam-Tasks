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
        
        public Music getInfoByMusic(string[] infoFromLine)
        {
            Music music = new Music();
            music.Type = infoFromLine[0];
            music.Name = infoFromLine[1];
            music.Size = Int32.Parse(infoFromLine[2]);
            music.DateOfCreation = infoFromLine[3];
            music.DateOfChange = infoFromLine[4];
            music.Duration = Int32.Parse(infoFromLine[5]);
            music.FlowRate = Int32.Parse(infoFromLine[6]);
            music.Genres = infoFromLine[7];
            music.Performer = infoFromLine[8];
            music.Album = infoFromLine[9];
            return music;
        }
        public override string ToString()
        {
            string result = "";
            result = Type + ' ' + Name + ' ' + Size + ' ' + DateOfCreation + ' ' + DateOfChange + ' ' 
                     + Duration + ' ' + FlowRate + ' ' + Genres + ' ' + Performer + ' ' + Album;
            return result;
        }
    }
}