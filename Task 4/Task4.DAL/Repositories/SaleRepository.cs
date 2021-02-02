using System;
using Task4.DAL.EF;
using Task4.DAL.Interfaces;
using Task4.DAL.Models;

namespace Task4.DAL.Repositories
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