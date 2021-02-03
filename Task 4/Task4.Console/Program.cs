using System.Configuration;
using Serilog;
using Serilog.Core;
using Task4.BL;

namespace Task4.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var directoryPath = ConfigurationManager.AppSettings["DirectoryPath"];
            var fileType = ConfigurationManager.AppSettings["FileType"];
            var logPath = ConfigurationManager.AppSettings["LogPath"];
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Information()
                .WriteTo.Console()
                .WriteTo.File(logPath)
                .CreateLogger();

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