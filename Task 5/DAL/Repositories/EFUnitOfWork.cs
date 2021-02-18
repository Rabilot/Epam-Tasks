using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using DAL.EF;
using DAL.Interfaces;
using DAL.Models;
using Model;
using Manager = DAL.Models.Manager;

namespace DAL.Repositories
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
                // ignored
            }

            //Console.WriteLine("Finished writing");
            Monitor.Exit(Locker);
        }

        public IList<SaleModel> GetAll()
        {
            var result = _db.Sales.ToList().Select(x => new SaleModel()
            {
                ClientModel = new ClientModel()
                {
                    Name = x.Client.Name
                },
                ManagerModel = new ManagerModel()
                {
                    LastName = x.Manager.LastName
                },
                ProductModel = new ProductModel()
                {
                    Name = x.Product.Name,
                    Price = x.Product.Price
                },
                DateOfSale = x.Date
            }).ToList();

            return result;
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