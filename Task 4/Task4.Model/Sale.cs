using System;

namespace Task4.Models
{
    public class Sale
    {
        public int Id { get; set; }
        public Client Client { get; set; }
        public Manager Manager { get; set; }
        public Product Product { get; set; }
        public DateTime Date { get; set; }
    }
}