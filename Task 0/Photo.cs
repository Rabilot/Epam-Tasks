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
        
        public Photo getInfoByPhoto(string[] infoFromLine)
        {
            Photo photo = new Photo();
            photo.Type = infoFromLine[0];
            photo.Name = infoFromLine[1];
            photo.Size = Int32.Parse(infoFromLine[2]);
            photo.DateOfCreation = infoFromLine[3];
            photo.DateOfChange = infoFromLine[4];
            photo.Length = Int32.Parse(infoFromLine[5]);
            photo.Width = Int32.Parse(infoFromLine[6]);
            photo.CameraName = infoFromLine[7];
            photo.ISO = Int32.Parse(infoFromLine[8]);
            //photo.ShutterSpeed = Double.Parse(infoFromLine[9]);
            return photo;
        }
        public override string ToString()
        {
            string result = "";
            result = Type + ' ' + Name + ' ' + Size + ' ' + DateOfCreation + ' ' + DateOfChange + ' ' 
                     + Length + ' ' + Width + ' ' + CameraName + ' ' + ISO + ' ' + ShutterSpeed;
            return result;
        }
    }
    
}