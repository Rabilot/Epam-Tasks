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
        void Add(SaleModel saleModel);
        IList<SaleModel> GetAll(string name, DateTime? fromDate, DateTime? toDate);
        SaleModel FindByIndex(int? index);
        void DeleteByIndex(int index);
        void Edit(SaleModel saleModel);
    }
}