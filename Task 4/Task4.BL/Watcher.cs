using System;
using System.Configuration;
using System.IO;
using System.Threading;

namespace Task4.BL
{
    public class Watcher : IDisposable
    {
        private readonly FileSystemWatcher _watcher;

        public Watcher(string directoryPath, string fileType)
        {
            var handler = new FileHandler(new Parser());
            _watcher = new FileSystemWatcher
            {
                Path = directoryPath,
                Filter = fileType,
            };
            _watcher.Created += handler.CreatedEventHandler;
        }

        public void Start()
        {
            _watcher.EnableRaisingEvents = true;
        }

        public void Stop()
        {
            _watcher.EnableRaisingEvents = false;
        }

        public void Dispose()
        {
            _watcher.Dispose();
        }
    }
}