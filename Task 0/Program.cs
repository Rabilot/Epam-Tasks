using System;
using System.IO;

namespace Task_0
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            string path = "C:\\Users\\rabil\\Desktop\\University\\EPAM\\Task 0\\Test.txt";
            Multimedia multimedia = new Multimedia();
            //multimedia = multimedia.GetMultimediaFromFile(path);
            multimedia.Deserialize();
            multimedia.AddMultimediaFromXML();
            multimedia.SafeByType();
            multimedia.Serialize();
            Console.WriteLine("Finished.");
        }
    }
}