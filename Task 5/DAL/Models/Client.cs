using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DAL.Models
{
    public class Client
    {
        public int Id { get; set; }
        [Required]
        [StringLength(64)]
        public string Name { get; set; }

        public ICollection<Sale> Sales { get; set; }

        public Client()
        {
            Sales = new List<Sale>();
        }
    }
}