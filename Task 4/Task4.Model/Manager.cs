using System.Collections.Generic;

namespace Task4.Model
{
    public class Manager
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        
        public ICollection<Sale> Sales { get; set; }
    }
}