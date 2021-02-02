using System.Collections.Generic;

namespace Task4.DAL.Models
{
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Sale> Sales { get; set; }
    }
}