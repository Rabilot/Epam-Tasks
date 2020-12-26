using System.IO;

namespace Task_2.Reader
{
    public class TxtFileReader : IFileReader
    {
        public string Read(string path)
        {
            var streamReader = new StreamReader(File.OpenRead(path));
            return streamReader.ReadToEnd();
        }
    }
}