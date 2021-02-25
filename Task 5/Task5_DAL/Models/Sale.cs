using System;
using System.ComponentModel.DataAnnotations;

namespace Task5_DAL.Models
{
    public class Sale
    {
        public int Id { get; set; }
        public int ManagerId { get; set; }
        public virtual Manager Manager { get; set; }
        public int ClientId { get; set; }
        public virtual Client Client { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        [Required]
        public DateTime Date { get; set; }
    }
}