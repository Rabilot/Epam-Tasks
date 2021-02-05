using System;

namespace Task4.BL.Interfaces
{
    public interface IWatcher : IDisposable
    {
        void Start();
        void Stop();
    }
}