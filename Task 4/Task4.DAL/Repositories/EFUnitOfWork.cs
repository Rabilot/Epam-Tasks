using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Serilog;
using Task4.DAL.EF;
using Task4.DAL.Interfaces;
using Task4.DAL.Models;

namespace Task4.DAL.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private readonly DatabaseContext _db;
        private SaleRepository _saleRepository;
        private static readonly object Locker = new object();
 
        public EFUnitOfWork()
        {
            _db = new DatabaseContext();
        }

        public IRepository<Sale> Sales => _saleRepository ?? (_saleRepository = new SaleRepository(_db));

        public void Add(IEnumerable<Sale> sales, Manager manager)
        {
            Monitor.Enter(Locker);
            //Console.WriteLine("Started writing");
            var createdManager = _db.Managers.FirstOrDefault(o => o.LastName == manager.LastName);
            if (createdManager != null)
            {
                manager = createdManager;
            }
            try
            {
                foreach (var sale in sales)
                {
                    sale.Manager = manager;
                    Sales.Add(sale);
                }
                Save();
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
            }
            
            //Console.WriteLine("Finished writing");
            Monitor.Exit(Locker);
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