using System.IO;

namespace Task_2.Reader
{
    public class TxtFileReader : IFileReader
    {
        public string Read(string path)
        {
            using (var fileStream = File.OpenRead(path))
            {
                var streamReader = new StreamReader(fileStream);
                var textString = streamReader.ReadToEnd();
                return textString;
            }
        }
    }
}