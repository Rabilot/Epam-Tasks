using System.Data.Entity;
using DAL.Models;

namespace DAL.EF
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