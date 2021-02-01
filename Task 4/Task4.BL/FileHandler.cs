using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using Task4.DAL.Interfaces;
using Task4.DAL.Repositories;
using Task4.Model;

namespace Task4.BL
{
    public class FileHandler
    {
        private readonly IParser _parser;

        public FileHandler(IParser parser)
        {
            _parser = parser;
        }

        public void Watcher_Created(object sender, FileSystemEventArgs e) 
        {
            var filePath = e.FullPath;
            var csvData = _parser.FileParse(filePath);
            var sales = Converter(csvData, GetManagerName(Path.GetDirectoryName(filePath)));
            DataSqlWriter(sales);
        }

        private IEnumerable<Sale> Converter(IEnumerable<CsvObject> csvObjects, string managerName)
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
            var stringBuilder = new StringBuilder();
            for (var i = 0; fileName[i] != '_'; i++)
            {
                stringBuilder.Append(fileName[i]);
            }

            return stringBuilder.ToString();
        }

        private void DataSqlWriter(IEnumerable<Sale> sales)
        {
            var lockSlim = new ReaderWriterLockSlim();
            lockSlim.EnterWriteLock();
            try
            {
                using (IUnitOfWork unitOfWork = new EFUnitOfWork())
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