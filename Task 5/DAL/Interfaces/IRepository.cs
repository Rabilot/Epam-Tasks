using System;

namespace DAL.Interfaces
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
        void Add(TEntity item);
        void Save();
    }
}