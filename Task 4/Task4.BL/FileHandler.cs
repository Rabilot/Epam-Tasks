using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using Task4.DAL.Interfaces;
using Task4.DAL.Models;
using Task4.DAL.Repositories;

namespace Task4.BL
{
    public class FileHandler
    {
        private readonly IParser _parser;

        public FileHandler(IParser parser)
        {
            _parser = parser;
        }

        public void CreatedEventHandler(object sender, FileSystemEventArgs e) 
        {
            var filePath = e.FullPath;
            var csvData = _parser.FileParse(filePath);
            var sales = Convert(csvData, GetManagerName(Path.GetFileName(filePath)));
            WriteDataToSQL(sales);
        }

        private IEnumerable<Sale> Convert(IEnumerable<CsvObject> csvObjects, string managerName)
        {
            var sales = new List<Sale>();
            foreach (var csvObject in csvObjects)
            {
                var sale = new Sale
                {
                    Client = new Client() {Name = csvObject.ClientName},
                    Manager = new Manager() {LastName = managerName},
                    Product = new Product() {Price = csvObject.Price, Name = csvObject.ProductName},
                    Date = csvObject.OrderDate
                };
                sales.Add(sale);
            }
            return sales;
        }

        private string GetManagerName(string fileName)
        {
            Console.WriteLine(fileName);
            return fileName.Substring(0, fileName.IndexOf('_')-1);
        }

        private void WriteDataToSQL(IEnumerable<Sale> sales)
        {
            var lockSlim = new ReaderWriterLockSlim();
            lockSlim.EnterWriteLock();
            try
            {
                using (IUnitOfWork unitOfWork = new UnitOfWork())
                {
                    foreach (var sale in sales)
                    {
                        unitOfWork.Sales.Add(sale);

                    }

                    unitOfWork.Save();
                }
            }
            finally
            {
                lockSlim.ExitWriteLock();
            }
        }
    }
}