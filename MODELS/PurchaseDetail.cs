using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODELS
{
    public class PurchaseDetail : CommonProps
    {
        [Display(Name = "Product Name")]
        public int ProductId { get; set; }

        [Display(Name = "Quantity")]
        public int PurchaseQty { get; set; }

        public double Price { get; set; }
        public double Discount { get; set; }
        public string Remark { get; set; }

        [Display(Name = "Purchase Code")]
        public int PurchaseId { get; set; }

        public Purchase Purchase { get; set; }
        public Product Product { get; set; }

    }
}
