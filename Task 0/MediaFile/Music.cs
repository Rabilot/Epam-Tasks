using System;

namespace Task_0
{
    public class Music : MediaFile
    {
        public int Duration { get; }
        public string Genres { get; }
        public string Performer { get; }
        public string Album { get; }

        public Music(string name, int size, string dateOfCreation, string type, 
            string path, int duration, string genres, string performer, 
            string album) : base(name, size, dateOfCreation, type, path)
        {
            Duration = duration;
            Genres = genres;
            Performer = performer;
            Album = album;
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public override void Play()
        {
            
        }
    }
}