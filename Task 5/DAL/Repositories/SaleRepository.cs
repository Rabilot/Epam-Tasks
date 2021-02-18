using System;
using DAL.EF;
using DAL.Interfaces;
using DAL.Models;

namespace DAL.Repositories
{
    public class SaleRepository : IRepository<Sale>
    {
        private readonly DatabaseContext _context;

        public SaleRepository(DatabaseContext context)
        {
            _context = context;
        }

        public void Add(Sale item)
        {
            if (item == null)
            {
                throw new ArgumentNullException();
            }
            
            _context.Sales.Add(item);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}