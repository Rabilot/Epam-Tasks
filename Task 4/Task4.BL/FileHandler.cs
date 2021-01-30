using System;
using System.Configuration;
using System.IO;
using System.Threading;

namespace Task4.BL
{
    public class FileHandler
    {
        readonly object _obj = new object();
        // создание файлов
        public void Watcher_Created(object sender, FileSystemEventArgs e) 
        {
            string filePath = e.FullPath;
            var csvData = new Parser().FileParse(filePath);
            string str = null;
            foreach (var obj in csvData)
            {
                str += $"{obj}\n";
            }
            RecordEntry(str, filePath);
        }

        private void RecordEntry(string fileEvent, string filePath)
        {
            lock (_obj)
            {
                using (StreamWriter writer = new StreamWriter("D:\\templog.txt", true))
                {
                    writer.WriteLine(fileEvent);
                    writer.Flush();
                }
            }
        }
    }
}