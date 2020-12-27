using System;
using System.IO;
using System.Text;

namespace Task_2.Writer
{
    public class FileWriter : IInfoWriter
    {
        private readonly FileStream _fileStream;

        public FileWriter(string path)
        {
            if (path == null)
            {
                throw new NullReferenceException();
            }

            _fileStream = new FileStream(path, FileMode.Create);
        }

        public void WriteLine(string str)
        {
            var textByte = Encoding.Default.GetBytes($"{str}\n");
            _fileStream.Write(textByte, 0, textByte.Length);
        }

        public void Write(string str)
        {
            var textByte = Encoding.Default.GetBytes($"{str}");
            _fileStream.Write(textByte, 0, textByte.Length);
        }

        ~FileWriter()
        {
            _fileStream.Dispose();
        }
    }
}