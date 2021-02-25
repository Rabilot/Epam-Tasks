using System;

namespace Task5_DAL.Interfaces
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
        void Add(TEntity item);
        void Save();
    }
}