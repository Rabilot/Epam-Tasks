using System.ServiceProcess;
using System.Threading;

namespace Task4.WindowsService
{
    public partial class FileWatcherService : ServiceBase
    {
        private Watcher _watcher;

        public FileWatcherService()
        {
            InitializeComponent();
            this.CanStop = true;
            this.CanPauseAndContinue = true;
            this.AutoLog = true;
        }

        protected override void OnStart(string[] args)
        {
            _watcher = new Watcher();
            var loggerThread = new Thread(new ThreadStart(_watcher.Start));
            loggerThread.Start();
        }

        protected override void OnStop()
        {
            _watcher.Stop();
            _watcher.Dispose();
            Thread.Sleep(1000);
        }
    }
}