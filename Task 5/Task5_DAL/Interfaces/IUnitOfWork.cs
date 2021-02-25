using System;
using System.Collections.Generic;
using Model;
using Task5_DAL.Models;

namespace Task5_DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Sale> Sales { get; }
        void Save();
        void Add(IEnumerable<Sale> sales, Manager manager);
        IList<SaleModel> GetAll();
    }
}