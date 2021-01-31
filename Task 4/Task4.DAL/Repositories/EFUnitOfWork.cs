using System;
using Task4.DAL.EF;
using Task4.DAL.Interfaces;
using Task4.Model;

namespace Task4.DAL.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private DatabaseContext _db;
        private SaleRepository _saleRepository;

        public EFUnitOfWork()
        {
            _db = new DatabaseContext();
        }

        public IRepository<Sale> Sales
        {
            get
            {
                if (_saleRepository == null)
                    _saleRepository = new SaleRepository(_db);
                return _saleRepository;
            }
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Dispose()
        {
            _db?.Dispose();
        }

    }
}