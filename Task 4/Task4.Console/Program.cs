using System.Configuration;
using System.IO;
using Task4.BL;

namespace Task4.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var directoryPath = ConfigurationManager.AppSettings["FilePath"];
            var filesFilter = ConfigurationManager.AppSettings["FileType"];

            FileWatcher(directoryPath, filesFilter);
        }


        private static void FileWatcher(string directoryPath, string fileType)
        {
            using (var watcher = new FileSystemWatcher())
            {
                var fileHandler = new FileHandler(new Parser());
                watcher.Path = directoryPath;
                watcher.Filter = fileType;
                watcher.Created += fileHandler.Watcher_Created;
                watcher.EnableRaisingEvents = true;

                System.Console.WriteLine("Press 'q' to quit the watcher.");
                while (System.Console.Read() != 'q')
                {
                }
            }
        }
    }
}