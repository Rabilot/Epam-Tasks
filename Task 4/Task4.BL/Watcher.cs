using System;
using System.IO;
using Serilog;
using Task4.BL.Interfaces;

namespace Task4.BL
{
    public class Watcher : IWatcher
    {
        private readonly FileSystemWatcher _watcher;
        private readonly IFileHandler _handler;

        public Watcher(string directoryPath, string fileType, IFileHandler fileHandler)
        {
            _handler = fileHandler;
            if (string.IsNullOrEmpty(directoryPath) || string.IsNullOrEmpty(fileType))
            {
                throw new ArgumentException();
            }
            
            try
            {
                _watcher = new FileSystemWatcher
                {
                    Path = directoryPath,
                    Filter = fileType,
                };
                _watcher.Created += _handler.CreatedEventHandler;
            }
            catch (ArgumentException e)
            {
                Log.Error(e.Message);
            }
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
            Stop();
            _watcher.Created -= _handler.CreatedEventHandler;
            _watcher.Dispose();
        }
    }
}