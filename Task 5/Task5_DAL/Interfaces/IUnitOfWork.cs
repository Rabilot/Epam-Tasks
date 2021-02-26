using System;
using System.Collections.Generic;
using Task5_DAL.Models;
using Task5_Model;

namespace Task5_DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Sale> Sales { get; }
        void Save();
        void Add(IEnumerable<Sale> sales, Manager manager);
        IList<SaleModel> GetAll(int? page, string name, DateTime? fromDate, DateTime? toDate);
    }
}