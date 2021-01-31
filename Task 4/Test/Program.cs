using System;
using System.IO;
using System.Security.Permissions;
using Task4.BL;
using Task4.DAL.EF;
using Task4.Model;

namespace Test
{
    internal class Program
    {
        public static void Main()
        {
            using (var ctx = new DatabaseContext())
            {
                Client client = new Client();
                client.Name = "ExampleClient2";
                Manager manager = new Manager();
                manager.LastName = "ExampleManager2";
                Product product = new Product();
                product.Name = "ExampleProduct2";
                product.Price = 140;
                Sale sale = new Sale() {Client = client, Manager = manager, Product = product, Date = "11.11.2511"};
                // List<Sale> sales = new List<Sale>();
                // sales.Add(sale);
                //DataSqlWriter(sale);
                // foreach (var sal in sales)
                // {
                //     System.Console.WriteLine(sal);
                //     
                // }
                ctx.Sales.Add(sale);
                ctx.SaveChanges();
            }
        }
    }
}