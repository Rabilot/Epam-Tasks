using System;

namespace Task_0
{
    public class VideoFile : MediaFile
    {
        private int FrameLength { get; }
        private int FrameWidth { get; }
        private int FrameRate { get; }

        public VideoFile(string name, int size, string dateOfCreation, string type, string path,
            int frameLength, int frameWidth, int frameRate) : base(name, size, dateOfCreation, type, path)
        {
            FrameLength = frameLength;
            FrameWidth = frameWidth;
            FrameRate = frameRate;
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