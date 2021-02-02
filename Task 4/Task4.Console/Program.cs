using System.Configuration;
using Task4.BL;

namespace Task4.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var directoryPath = ConfigurationManager.AppSettings["DirectoryPath"];
            var filesFilter = ConfigurationManager.AppSettings["FileType"];

            FileWatcher(directoryPath, filesFilter);
        }

        private static void FileWatcher(string directoryPath, string fileType)
        {
            using (var watcher = new Watcher(directoryPath, fileType))
            {
                watcher.Start();

                System.Console.WriteLine("Press 'q' to quit the watcher.");
                while (System.Console.Read() != 'q')
                {
                }
            }
        }
    }
}