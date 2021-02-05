using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using CsvHelper;
using Serilog;
using Task4.BL.Csv_Handling;
using Task4.BL.Interfaces;
using Task4.DAL.Interfaces;
using Task4.DAL.Models;
using Task4.DAL.Repositories;
using IReader = Task4.BL.Interfaces.IReader;

namespace Task4.BL
{
    public class FileHandler : IFileHandler
    {
        private readonly IReader _reader;

        public FileHandler(IReader reader)
        {
            _reader = reader;
        }

        public void CreatedEventHandler(object sender, FileSystemEventArgs e)
        {
            Task.Factory.StartNew(() =>
            {
                var filePath = e.FullPath;
                try
                {
                    Log.Information($"New file {e.Name}");
                    var csvData = _reader.ReadFile(filePath);
                    var sales = ConvertToIEnumerable(csvData);
                    WriteToSQL(sales, GetManagerName(e.Name));
                }
                catch (HeaderValidationException)
                {
                    Log.Error(
                        $"{e.Name} | Invalid file data. File must contain ID | Date | Client name | Name of product | Price");
                }
                catch (System.MissingFieldException)
                {
                    Log.Error($"{e.Name} | Invalid file data");
                }
                catch (TypeLoadException exception)
                {
                    Log.Error(exception.Message);
                }
                catch (ArgumentOutOfRangeException)
                {
                    Log.Error($"{e.Name} | Invalid file name");
                }
                catch (FormatException)
                {
                    Log.Error($"{e.Name} | Invalid data");
                }
                catch (Exception exception)
                {
                    Log.Error($"{e.Name} | {exception.Message}");
                }
            });
        }

        private IEnumerable<Sale> ConvertToIEnumerable(IEnumerable<CsvObject> csvObjects)
        {
            var sales = new List<Sale>();
            foreach (var csvObject in csvObjects)
            {
                var sale = new Sale
                {
                    Client = new Client() {Name = csvObject.ClientName},
                    Product = new Product() {Price = csvObject.Price, Name = csvObject.ProductName},
                    Date = Convert.ToDateTime(csvObject.OrderDate).Date
                };
                sales.Add(sale);
            }

            return sales;
        }

        private Manager GetManagerName(string fileName)
        {
            var managerName = fileName.Substring(0, fileName.IndexOf('_'));
            return new Manager() {LastName = managerName};
        }

        private void WriteToSQL(IEnumerable<Sale> sales, Manager manager)
        {
            using (IUnitOfWork unitOfWork = new EFUnitOfWork())
            {
                unitOfWork.Add(sales, manager);
            }
        }
    }
}