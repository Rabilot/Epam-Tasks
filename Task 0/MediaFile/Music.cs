using System;

namespace Task_0
{
    public class Music : MediaFile
    {
        private int Duration { get; }
        private string Genres { get; }
        private string Performer { get; }
        private string Album { get; }

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