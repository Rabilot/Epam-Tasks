using System;
using Task4.Model;

namespace Task4.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Sale> Sales { get; }
        void Save();
    }
}