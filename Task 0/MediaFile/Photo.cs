﻿using System.IO;
using System;
using System.Runtime.CompilerServices;

namespace Task_0
{
    public class Photo : MediaFile
    {
        public int Length { get; }
        public int Width { get; }
        public string CameraName { get; }

        public Photo(string name, int size, string dateOfCreation, string type, string path, int length, 
            int width, string cameraName) : base(name, size, dateOfCreation, type, path)
        {
            Length = length;
            Width = width;
            CameraName = cameraName;
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