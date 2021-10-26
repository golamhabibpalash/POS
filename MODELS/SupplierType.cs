using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODELS
{
    public class SupplierType : CommonProps
    {
        [Display(Name="Supplier Type Name")]
        public string SupplierTypeName { get; set; }
        public string Description { get; set; }
        public ICollection<Supplier> Suppliers { get; set; }
    }
}
