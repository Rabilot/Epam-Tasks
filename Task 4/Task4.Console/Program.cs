using System;
using System.Configuration;
using Serilog;
using Task4.BL;
using Task4.BL.Csv_Handling;
using Task4.BL.Interfaces;

namespace Task4.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var logPath = ConfigurationManager.AppSettings["LogPath"];
                Log.Logger = new LoggerConfiguration()
                    .WriteTo.Console()
                    .WriteTo.File(logPath)
                    .CreateLogger();
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e);
            }
            
            try
            {
                var directoryPath = ConfigurationManager.AppSettings["DirectoryPath"];
                var fileType = ConfigurationManager.AppSettings["FileType"];

                using (IWatcher watcher = new Watcher(directoryPath, fileType, new FileHandler(new Reader())))
                {
                    watcher.Start();

                    System.Console.WriteLine("Press 'q' to quit the watcher.");
                    while (System.Console.Read() != 'q')
                    {
                    }
                }
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
            }
        }
    }
}