using System;

namespace Task_0
{
    public class VideoFile : MediaFile
    {
        public int FrameLength;
        public int FrameWidth;
        public int FrameRate;
        public int Duration;
        
        public VideoFile getInfoByVideo(string[] infoFromLine)
        {
            VideoFile video = new VideoFile();
            video.Type = infoFromLine[0];
            video.Name = infoFromLine[1];
            video.Size = Int32.Parse(infoFromLine[2]);
            video.DateOfCreation = infoFromLine[3];
            video.DateOfChange = infoFromLine[4];
            video.FrameLength = Int32.Parse(infoFromLine[5]);
            video.FrameWidth = Int32.Parse(infoFromLine[6]);
            video.FrameRate = Int32.Parse(infoFromLine[7]);
            video.Duration = Int32.Parse(infoFromLine[8]);
            return video;
        }

        public override string ToString()
        {
            string result = "";
            result = Type + ' ' + Name + ' ' + Size + ' ' + DateOfCreation + ' ' + DateOfChange + ' ' 
                              + FrameLength + ' ' + FrameWidth + ' ' + FrameRate + ' ' + Duration;
            return result;
        }
    }
}