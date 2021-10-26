using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APP.ViewModels.PurchaseVM
{
    public class CreatePurchaseVM
    {
        [Display(Name = "Purchase Code")]
        public string PurchaseCode { get; set; }

        [Display(Name = "Purchase Date")]
        public DateTime PurchaseDate { get; set; }

        [Display(Name = "Supplier")]
        public int SupplierId { get; set; }

        public string PurchaseRemark { get; set; }

        [Display(Name = "Total")]
        public double PurchaseAmount { get; set; }

        [Display(Name = "Product Name")]
        public int ProductId { get; set; }

        [Display(Name = "Quantity")]
        public int PurchaseQty { get; set; }

        public double Price { get; set; }
        public double Discount { get; set; }

        public string PurchaseDetailRemark { get; set; }
    }
}
