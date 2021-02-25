using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Task5_DAL.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        [Column(TypeName = "money")]
        [Display(Name = "Price")]
        public decimal Price { get; set; }
        
        public ICollection<Sale> Sales { get; set; }

        public Product()
        {
            Sales = new List<Sale>();
        }
    }
}