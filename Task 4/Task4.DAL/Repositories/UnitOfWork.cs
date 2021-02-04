using System;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using System.Threading;
using Serilog;
using Task4.DAL.EF;
using Task4.DAL.Interfaces;
using Task4.DAL.Models;

namespace Task4.DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DatabaseContext _db;
        private SaleRepository _saleRepository;
        private static readonly object Locker = new object();
 
        public UnitOfWork()
        {
            _db = new DatabaseContext();
        }

        public IRepository<Sale> Sales => _saleRepository ?? (_saleRepository = new SaleRepository(_db));

        public void Add(IEnumerable<Sale> sales)
        {
            Monitor.Enter(Locker);
            //Console.WriteLine("Started writing");
            try
            {
                foreach (var sale in sales)
                {
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