using System;

namespace Task_0
{
    public abstract class MediaFile 
    {
        public string Name { get; }
        public int Size { get; }
        public string DateOfCreation { get; }
        public string Type { get; }
        public string Path { get; }

        protected MediaFile(string name, int size, string dateOfCreation, string type, string path)
        {
            Name = name;
            Size = size;
            DateOfCreation = dateOfCreation;
            Type = type;
            Path = path;
        }

        public abstract void Play();
    }
}