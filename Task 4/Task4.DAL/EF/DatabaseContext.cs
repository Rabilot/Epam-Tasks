﻿using System.Data.Entity;
using Task4.DAL.Models;

namespace Task4.DAL.EF
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() : base("name=con")
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<Manager> Managers { get; set; }
    }
}