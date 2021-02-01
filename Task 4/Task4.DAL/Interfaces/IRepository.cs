using System;
using System.Collections.Generic;

namespace Task4.DAL.Interfaces
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
        IEnumerable<TEntity> Find(Func<TEntity, bool> predicate);
        IEnumerable<TEntity> GetAll();
        void Delete(TEntity item);
        void Add(TEntity item);
        void Save();
    }
}