using System;

namespace Task4.DAL.Interfaces
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
        void Add(TEntity item);
        void Save();
    }
}