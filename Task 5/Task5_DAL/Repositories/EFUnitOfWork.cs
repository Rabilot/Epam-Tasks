﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading;
using Task5_DAL.EF;
using Task5_DAL.Interfaces;
using Task5_DAL.Models;
using Task5_Model;
using Manager = Task5_DAL.Models.Manager;

namespace Task5_DAL.Repositories
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

        public void Add(IEnumerable<Sale> sales, Models.Manager manager)
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

        public void DeleteByIndex(int index)
        {
            Monitor.Enter(Locker);
            var sale = _db.Sales.Find(index);
            if (sale != null)
            {
                _db.Managers.Remove(_db.Managers.Find(sale.ManagerId) ?? throw new InvalidOperationException());
                _db.Clients.Remove(_db.Clients.Find(sale.ClientId) ?? throw new InvalidOperationException());
                _db.Products.Remove(_db.Products.Find(sale.ProductId) ?? throw new InvalidOperationException());
                _db.Sales.Remove(sale);
            }

            _db.SaveChanges();
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

        public IList<SaleModel> GetAll(int? page, string name, DateTime? fromDate, DateTime? toDate)
        {
            if (fromDate == null)
            {
                fromDate = DateTime.MinValue;
            }

            if (toDate == null)
            {
                toDate = DateTime.MaxValue;
            }
            
            var result = _db.Sales
                .Where(sale => (string.IsNullOrEmpty(name) || sale.Manager.LastName == name) && sale.Date >= fromDate &&
                               sale.Date <= toDate)
                .ToList().Select(x => new SaleModel() //.OrderBy(o => o.Date).Skip(10*2).Take(10)
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
                Manager = new Models.Manager()
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