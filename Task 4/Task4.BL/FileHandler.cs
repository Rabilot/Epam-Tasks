using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using CsvHelper;
using Task4.DAL.Interfaces;
using Task4.DAL.Models;
using Task4.DAL.Repositories;
using Serilog;

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
            var filePath = e.FullPath;
            try
            {
                var csvData = _reader.ReadFile(filePath);
                var sales = Convert(csvData, GetManagerName(Path.GetFileName(filePath)));
                WriteDataToSQL(sales);
            }
            catch (HeaderValidationException)
            {
                Log.Error("Invalid file data. File must contain ID | Date | Client name | Name of product | Price");
            }
            catch (System.MissingFieldException)
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
                    Date = System.Convert.ToDateTime(csvObject.OrderDate).Date
                };
                sales.Add(sale);
            }

            return sales;
        }

        private string GetManagerName(string fileName)
        {
            return fileName.Substring(0, fileName.IndexOf('_'));
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