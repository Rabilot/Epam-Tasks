using System;

namespace Task_0
{
    public class VideoFile : MediaFile
    {
        public int FrameLength;
        public int FrameWidth;
        public int FrameRate;
        public int Duration;
        
        public VideoFile GetInfoByVideo(string[] infoFromLine)
        {
            return new VideoFile();
        }
    }
}