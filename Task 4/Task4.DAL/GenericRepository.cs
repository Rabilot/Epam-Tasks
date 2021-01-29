using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Task4.DAL
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private DbContext _context;
        private DbSet<TEntity> _dbSet;

        public GenericRepository(DbContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }
        
        public IEnumerable<TEntity> Get(Func<TEntity, bool> predicate)
        {
            return predicate != null ? _dbSet.AsNoTracking().Where(predicate).ToList() : _dbSet.ToList();
        }

        public void Add(TEntity item)
        {
            if (item == null)
            {
                throw new ArgumentNullException();
            }
            _dbSet.Add(item);
        }


        public void Save()
        {
            _context.SaveChanges();
        }

        public void Remove(TEntity item)
        {
            if (item == null)
            {
                throw new ArgumentNullException();
            }
            _dbSet.Remove(item);
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}