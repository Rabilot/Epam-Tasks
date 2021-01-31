using System;
using System.Configuration;
using System.IO;
using System.Threading;
using Task4.BL;

namespace Task4.WindowsService
{
    public class Watcher : IDisposable
    {
        readonly FileSystemWatcher _watcher;
        bool _enabled = true;
        public Watcher()
        {
            var handler = new FileHandler(new Parser());
            _watcher = new FileSystemWatcher();
            _watcher.Path = ConfigurationManager.AppSettings["FilePath"];
            _watcher.Filter = ConfigurationManager.AppSettings["FileType"];
            _watcher.Created += handler.Watcher_Created;
        }
 
        public void Start()
        {
            _watcher.EnableRaisingEvents = true;
            while(_enabled)
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