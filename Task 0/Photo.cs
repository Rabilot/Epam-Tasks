using System.IO;
using System;

namespace Task_0
{
    public class Photo : MediaFile
    {
        public int Length;
        public int Width;
        public string CameraName;
        public int ISO;
        public double ShutterSpeed =  0;
        
        public Photo GetInfoByPhoto(string[] infoFromLine)
        {
            return new Photo();
        }
    }
    
}