using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using CsvHelper;
using Serilog;
using Task4.DAL.Interfaces;
using Task4.DAL.Models;
using Task4.DAL.Repositories;
using MissingFieldException = System.MissingFieldException;

namespace Task4.BL
{
    public class FileHandler
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
                    var sales = ConvertToIEnumerable(csvData, GetManagerName(e.Name));
                    WriteToSQL(sales);
                    Thread.Sleep(1000);
                }
                catch (HeaderValidationException)
                {
                    Log.Error("Invalid file data. File must contain ID | Date | Client name | Name of product | Price");
                }
                catch (MissingFieldException)
                {
                    Log.Error("Invalid file data");
                }
                catch (TypeLoadException exception)
                {
                    Log.Error(exception.Message);
                }
                catch (ArgumentOutOfRangeException)
                {
                    Log.Error("Invalid file name");
                }
                catch (FormatException)
                {
                    Log.Error("Invalid data");
                }
                catch (Exception exception)
                {
                    Log.Error(exception.Message);
                }
            });
        }

        private IEnumerable<Sale> ConvertToIEnumerable(IEnumerable<CsvObject> csvObjects, string managerName)
        {
            var sales = new List<Sale>();
            foreach (var csvObject in csvObjects)
            {
                var sale = new Sale
                {
                    Client = new Client() {Name = csvObject.ClientName},
                    Manager = new Manager() {LastName = managerName},
                    Product = new Product() {Price = csvObject.Price, Name = csvObject.ProductName},
                    Date = Convert.ToDateTime(csvObject.OrderDate).Date
                };
                sales.Add(sale);
            }

            return sales;
        }

        private string GetManagerName(string fileName)
        {
            return fileName.Substring(0, fileName.IndexOf('_'));
        }

        private void WriteToSQL(IEnumerable<Sale> sales)
        {
            using (IUnitOfWork unitOfWork = new UnitOfWork())
            {
                unitOfWork.Add(sales);
            }
        }
    }
}