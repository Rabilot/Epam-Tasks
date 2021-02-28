using System;
using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace Task5_Model
{
    public class SaleModel
    {
        public int Id { get; set; }
        public ManagerModel ManagerModel { get; set; }
        public ClientModel ClientModel { get; set; }
        public ProductModel ProductModel { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Purchase date")]
        public DateTime DateOfSale { get; set; }

        public bool IsValid()
        {
            return ManagerModel.LastName.Length <= 20 && ClientModel.Name.Length <= 64 &&
                   ProductModel.Name.Length <= 50 && ProductModel.Price > 0 && DateOfSale <= DateTime.Now;
        }
    }
}