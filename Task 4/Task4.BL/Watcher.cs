using System;
using System.IO;

namespace Task4.BL
{
    public class Watcher : IDisposable
    {
        private readonly FileSystemWatcher _watcher;

        public Watcher(string directoryPath, string fileType)
        {
            var handler = new FileHandler(new Reader());
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
                Console.WriteLine(e);
                throw;
            }
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