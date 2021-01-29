using System;
using System.Collections.Generic;

namespace Task4.DAL
{
    public interface IGenericRepository<TEntity>: IDisposable where TEntity : class
    {
        IEnumerable<TEntity> Get(Func<TEntity, bool> predicate);
        void Remove(TEntity item);
        void Add(TEntity item);
        void Save();
    }
}