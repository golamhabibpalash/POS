using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODELS
{
    public class Purchase : CommonProps
    {
        [Display(Name = "Purchase Code")]
        public string PurchaseCode { get; set; }

        [Display(Name = "Purchase Date")]
        public DateTime PurchaseDate { get; set; }

        [Display(Name = "Supplier")]
        public int SupplierId { get; set; }

        public string Remark { get; set; }
        [Display(Name = "Total")]
        public double PurchaseAmount { get; set; }

        public Supplier Supplier { get; set; }
        public List<PurchaseDetail> PurchaseDetails { get; set; }
    }
}
