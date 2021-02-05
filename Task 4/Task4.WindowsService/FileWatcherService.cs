using System;
using System.Configuration;
using System.ServiceProcess;
using System.Threading;
using Serilog;
using Task4.BL;
using Task4.BL.Csv_Handling;
using Task4.BL.Interfaces;

namespace Task4.WindowsService
{
    public partial class FileWatcherService : ServiceBase
    {
        private IWatcher _watcher;
        private Thread _thread;

        public FileWatcherService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            var logPath = ConfigurationManager.AppSettings["LogPath"];
            Log.Logger = new LoggerConfiguration()
                .WriteTo.File(logPath) //, rollingInterval: RollingInterval.Day
                .CreateLogger();
            try
            {
                var directoryPath = ConfigurationManager.AppSettings["DirectoryPath"];
                var fileType = ConfigurationManager.AppSettings["FileType"];
                _watcher = new Watcher(directoryPath, fileType, new FileHandler(new Reader()));
                _thread = new Thread(_watcher.Start);
                _thread.Start();
                Log.Information("Service Started");
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                Stop();
            }
        }

        protected override void OnStop()
        {
            _watcher.Stop();
            _watcher.Dispose();
            _thread.Abort();
            Log.Information("Service Stopped");
        }
    }
}