using System;
using System.Collections.Generic;
using System.Linq;
using Task4.DAL.EF;
using Task4.DAL.Interfaces;
using Task4.Model;

namespace Task4.DAL.Repositories
{
    public class SaleRepository : IRepository<Sale>
    {
        private DatabaseContext _context;
        //private DbSet<Sale> _dbSet;

        public SaleRepository(DatabaseContext context)
        {
            _context = context;
            //_dbSet = context.Set<TEntity>();
        }

        public IEnumerable<Sale> GetAll()
        {
            //return predicate != null ? _dbSet.AsNoTracking().Where(predicate).ToList() : _dbSet.ToList();
            return _context.Sales;
        }

        public IEnumerable<Sale> Find(Func<Sale, Boolean> predicate)
        {
            return predicate != null
                ? _context.Sales.AsNoTracking().Where(predicate).ToList()
                : _context.Sales.ToList();
        }

        public void Add(Sale item)
        {
            if (item == null)
            {
                throw new ArgumentNullException();
            }

            //_dbSet.Add(item);
            _context.Sales.Add(item);
        }


        public void Save()
        {
            _context.SaveChanges();
        }

        public void Delete(Sale item)
        {
            if (item == null)
            {
                throw new ArgumentNullException();
            }

            //_dbSet.Remove(item);
            _context.Sales.Remove(item);
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}