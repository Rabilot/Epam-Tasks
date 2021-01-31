using System.Collections.Generic;

namespace Task4.Model
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        
        public ICollection<Sale> Sales { get; set; }
    }
}