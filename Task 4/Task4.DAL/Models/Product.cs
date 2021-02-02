using System.Collections.Generic;

namespace Task4.DAL.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        
        public ICollection<Sale> Sales { get; set; }
    }
}