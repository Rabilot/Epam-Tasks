using System;

namespace Model
{
    public class SaleModel
    {
        public int Id { get; set; }
        public ManagerModel ManagerModel { get; set; }
        public ClientModel ClientModel { get; set; }
        public ProductModel ProductModel { get; set; }
        public DateTime DateOfSale { get; set; }
    }
}