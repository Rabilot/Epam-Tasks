using System;
using System.ComponentModel.DataAnnotations;

namespace Model
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
    }
}