using System;

namespace Task_0
{
    public class VideoFile : MediaFile
    {
        public int FrameLength { get; }
        public int FrameWidth { get; }
        public int FrameRate { get; }

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