using System;
using System.IO;
using Serilog;

namespace Task4.BL
{
    public class Watcher : IDisposable
    {
        private readonly FileSystemWatcher _watcher;
        private readonly FileHandler _handler;

        public Watcher(string directoryPath, string fileType)
        {
            _handler = new FileHandler(new Reader());
            try
            {
                _watcher = new FileSystemWatcher
                {
                    Path = directoryPath,
                    Filter = fileType,
                };
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
            }
            _watcher.Created += _handler.CreatedEventHandler;
        }

        public void Start()
        {
            _watcher.EnableRaisingEvents = true;
            Log.Information("Watcher Started");
        }

        public void Stop()
        {
            _watcher.EnableRaisingEvents = false;
            Log.Information("Watcher Stopped");
        }

        public void Dispose()
        {
            _watcher.Created -= _handler.CreatedEventHandler;
            _watcher.Dispose();
        }
    }
}