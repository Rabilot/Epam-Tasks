namespace Task4.DAL.Models
{
    public class Sale
    {
        public int Id { get; set; }
        public int ManagerId { get; set; }
        public Manager Manager { get; set; }
        public int ClientId { get; set; }
        public Client Client { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public string Date { get; set; }

        public override string ToString()
        {
            return $"{Client.Name} {Manager.LastName} {Product.Name} {Product.Price} {Date}";
        }
    }
}