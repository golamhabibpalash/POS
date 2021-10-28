using System.ComponentModel.DataAnnotations;

namespace MODELS
{
    public class Supplier : CommonProps
    {
        [Display(Name = "Name")]
        public string SupplierName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Image { get; set; }
        public string Address { get; set; }
        [Display(Name = "Supplier Type")]
        public int SupplierTypeId { get; set; }
        public SupplierType SupplierType { get; set; }
    }
}
