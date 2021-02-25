using System;
using Task5_DAL.EF;
using Task5_DAL.Interfaces;
using Task5_DAL.Models;

namespace Task5_DAL.Repositories
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