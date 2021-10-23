using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODELS
{
    public class SaleDetail : CommonProps
    {

        [Display(Name = "Sale Code")]
        public int SaleId { get; set; }

        [Display(Name = "Prduct")]
        public int ProductId { get; set; }

        [Display(Name = "Quantity")]
        public int SaleQty { get; set; }
        public string Remark { get; set; }
        public int CustomerId { get; set; }

        public Customer Customer { get; set; }
        public Product Product { get; set; }
        public Sale Sale { get; set; }
    }
}
