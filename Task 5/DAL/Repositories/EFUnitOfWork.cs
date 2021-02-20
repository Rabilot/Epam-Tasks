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

        public void Add(SaleModel saleModel)
        {
            var sale = Convert(saleModel);
            Monitor.Enter(Locker);
            var createdManager = _db.Managers.FirstOrDefault(o => o.LastName == sale.Manager.LastName);
            if (createdManager != null)
            {
                sale.Manager = createdManager;
            }
            try
            {
                Sales.Add(sale);
                Save();
            }
            catch (Exception e)
            {
                // ignored
            }
            Monitor.Exit(Locker);
        }

        public void Edit(SaleModel saleModel)
        {
            Monitor.Enter(Locker);
            var sale = _db.Sales.Find(saleModel.Id);
            if (sale != null)
            {
                sale.Client.Name = saleModel.ClientModel.Name;
                sale.Manager.LastName = saleModel.ManagerModel.LastName;
                sale.Product.Name = saleModel.ProductModel.Name;
                sale.Product.Price = saleModel.ProductModel.Price;
                sale.Date = saleModel.DateOfSale;
                _db.SaveChanges();
            }
            Monitor.Exit(Locker);
        }

        public SaleModel FindByIndex(int? index)
        {
            var sale = _db.Sales.Find(index);
            if (sale != null)
                return new SaleModel()
                {
                    ClientModel = new ClientModel()
                    {
                        Name = sale.Client.Name
                    },
                    ManagerModel = new ManagerModel()
                    {
                        LastName = sale.Manager.LastName
                    },
                    ProductModel = new ProductModel()
                    {
                        Name = sale.Product.Name,
                        Price = sale.Product.Price
                    },
                    DateOfSale = sale.Date
                };
            
            throw new ArgumentNullException();
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
                DateOfSale = x.Date,
                Id = x.Id
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

        private Sale Convert(SaleModel saleModel)
        {
            return new Sale()
            {
                Client = new Client()
                {
                    Name = saleModel.ClientModel.Name
                },
                Manager = new Manager()
                {
                    LastName = saleModel.ManagerModel.LastName
                },
                Product = new Product()
                {
                    Name = saleModel.ProductModel.Name,
                    Price = saleModel.ProductModel.Price
                },
                Date = saleModel.DateOfSale
            };
        }
    }
}