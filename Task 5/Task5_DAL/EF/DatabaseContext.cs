using System.Data.Entity;
using Task5_DAL.Models;

namespace Task5_DAL.EF
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() : base("name=DefaultConnection")
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<Manager> Managers { get; set; }
    }
}