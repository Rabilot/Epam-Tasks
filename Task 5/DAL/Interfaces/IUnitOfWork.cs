using System;
using System.Collections.Generic;
using DAL.Models;
using Model;

namespace DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Sale> Sales { get; }
        void Save();
        void Add(IEnumerable<Sale> sales, Manager manager);
        IList<SaleModel> GetAll();
    }
}