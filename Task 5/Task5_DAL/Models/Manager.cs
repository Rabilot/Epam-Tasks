using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Task5_DAL.Models
{
    public class Manager
    {
        public int Id { get; set; }
        [Required]
        [StringLength(20)]
        public string LastName { get; set; }
        
        public ICollection<Sale> Sales { get; set; }

        public Manager()
        {
            Sales = new List<Sale>();
        }
    }
}