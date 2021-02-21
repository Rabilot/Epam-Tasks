using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DAL.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        public double Price { get; set; }
        
        public ICollection<Sale> Sales { get; set; }

        public Product()
        {
            Sales = new List<Sale>();
        }
    }
}