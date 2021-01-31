using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using Task4.DAL.EF;
using Task4.DAL.Interfaces;
using Task4.DAL.Repositories;
using Task4.Model;

namespace Task4.BL
{
    public class FileHandler
    {
        private readonly object _obj = new object();

        private readonly IParser _parser;

        public FileHandler(IParser parser)
        {
            _parser = parser;
        }

        public void Watcher_Created(object sender, FileSystemEventArgs e)
        {
            var filePath = e.FullPath;
            var csvData = _parser.FileParse(filePath);
            var sales = Converter(csvData);
            var result = sales.Aggregate("", (current, sale) => current + $"{sale}\n");
            RecordEntry(result);
            
            using (var ctx = new DatabaseContext()) // Не работает
            {
                foreach (var sale in sales)
                {
                    ctx.Sales.Add(sale);
                    ctx.SaveChanges();
                }
            }
            
        }

        private void RecordEntry(string fileEvent)
        {
            lock (_obj)
            {
                using (var writer = new StreamWriter("D:\\templog.txt", true))
                {
                    writer.Write(fileEvent);
                    writer.Flush();
                }
            }
        }

        private List<Sale> Converter(IEnumerable<CsvObject> csvObjects)
        {
            string managerName = "DEFAULT";
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
            //var lockSlim = new ReaderWriterLockSlim();
            //lockSlim.EnterWriteLock();
            try
            {
                using (var ctx = new DatabaseContext())
                {
                    foreach (var sale in sales)
                    {
                        ctx.Sales.Add(sale);
                        ctx.SaveChanges();
                    }
                }


                // using (IUnitOfWork unitOfWork = new EFUnitOfWork())
                // {
                //     foreach (var sale in sales)
                //     {
                //         unitOfWork.Sales.Add(sale);
                //     }
                //     unitOfWork.Save();
                // }
            }
            finally
            {
                //lockSlim.ExitWriteLock();
            }
        }
    }
}