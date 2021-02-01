using System;
using System.Configuration;
using System.IO;
using System.Threading;

namespace Task4.BL
{
    public class Watcher : IDisposable
    {
        private readonly FileSystemWatcher _watcher;
        private bool _enabled = true;

        public Watcher()
        {
            var handler = new FileHandler(new Parser());
            _watcher = new FileSystemWatcher
            {
                Path = ConfigurationManager.AppSettings["FilePath"],
                Filter = ConfigurationManager.AppSettings["FileType"],
            };
            _watcher.Created += handler.Watcher_Created;
        }

        public void Start()
        {
            _watcher.EnableRaisingEvents = true;
            while (_enabled)
            {
                Thread.Sleep(1000);
            }
        }

        public void Stop()
        {
            _watcher.EnableRaisingEvents = false;
            _enabled = false;
        }

        public void Dispose()
        {
            _watcher.Dispose();
        }
    }
}