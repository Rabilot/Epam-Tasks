using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using Task4.DAL;
using Task4.Model;

namespace Task4.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var directoryPath = ConfigurationManager.AppSettings["FilePath"];
            var filesFilter = ConfigurationManager.AppSettings["FileType"];

            using (var ctx = new DatabaseContext())
            {
                var stud = new Client() {LastName = "AAA", FirstName = "BBB"};

                ctx.Clients.Add(stud);
                ctx.SaveChanges();
            }
        }
    }
}