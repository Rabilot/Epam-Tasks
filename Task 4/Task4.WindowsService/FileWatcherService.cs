using System.Configuration;
using System.ServiceProcess;
using System.Threading;
using Task4.BL;

namespace Task4.WindowsService
{
    public partial class FileWatcherService : ServiceBase
    {
        private Watcher _watcher;

        public FileWatcherService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            var directoryPath = ConfigurationManager.AppSettings["DirectoryPath"];
            var fileType = ConfigurationManager.AppSettings["FileType"];
            _watcher = new Watcher(directoryPath, fileType);
            var loggerThread = new Thread(_watcher.Start);
            loggerThread.Start();
        }

        protected override void OnStop()
        {
            _watcher.Stop();
            _watcher.Dispose();
        }
    }
}