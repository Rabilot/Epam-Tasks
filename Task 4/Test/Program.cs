using System.Collections.Generic;
using System.Threading;
using Task4.BL;
using Task4.DAL.EF;
using Task4.DAL.Interfaces;
using Task4.DAL.Repositories;
using Task4.Model;

namespace Test
{
    internal class Program
    {
        public static void Main()
        {
            // Client client = new Client();
            // client.Name = "ExampleClient2";
            // Manager manager = new Manager();
            // manager.LastName = "ExampleManager2";
            // Product product = new Product();
            // product.Name = "ExampleProduct2";
            // product.Price = 140;
            // Sale sale = new Sale() {Client = client, Manager = manager, Product = product, Date = "11.11.311"};
            // List<Sale> sales = new List<Sale>();
            // sales.Add(sale);
            // DataSqlWriter(sales);
            // foreach (var sal in sales)
            // {
            //     System.Console.WriteLine(sal);
            //     ctx.Sales.Add(sal);
            // }
            //
            // ctx.SaveChanges();
            var fileHandler = new FileHandler(new Parser());
            string file = "D:\\123.csv";
             var data = new Parser().FileParse(file);
             var finalData = Converter(data);
             DataSqlWriter(finalData);
            //fileHandler.Watcher_Created(file);
        }

        private static void DataSqlWriter(List<Sale> sales)
        {
            var lockSlim = new ReaderWriterLockSlim();
            lockSlim.EnterWriteLock();
            try
            {
                using (IUnitOfWork unitOfWork = new EFUnitOfWork())
                {
                    foreach (Sale sale in sales)
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

        private static List<Sale> Converter(IEnumerable<CsvObject> csvObjects)
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
    }
}