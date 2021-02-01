using System.Collections.Generic;
using System.ServiceProcess;
using System.Threading;
using Task4.BL;
using Task4.DAL.Interfaces;
using Task4.DAL.Repositories;
using Task4.Model;

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
            _watcher = new Watcher();
            var loggerThread = new Thread(_watcher.Start);
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