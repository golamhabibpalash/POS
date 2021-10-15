using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODELS
{
    public class Product: CommonProps
    {
        [Display(Name = "Name")]
        public string ProductName { get; set; }
        public string Image { get; set; }
        public string BarCode { get; set; }

        [Display(Name = "Quantity")]
        public int Qty { get; set; }

        [Display(Name = "Alart Qty")]
        public int AlertQty { get; set; }

        [Display(Name = "Measure Unit")]
        public string UoM { get; set; }

        [Display(Name = "Manufacturing Date")]
        public DateTime ManufacturingDate { get; set; }

        [Display(Name = "Expiry Date")]
        public DateTime ExpiryDate { get; set; }

        [Display(Name = "Brand")]
        public int? BrandId { get; set; }

        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        [Display(Name = "Product Type")]
        public int ProductTypeId { get; set; }

        [Display(Name = "Is Available")]
        public bool IsAvailable { get; set; }
        public string Description { get; set; }

        public Category Category { get; set; }
        public Brand Brand { get; set; }
        public ProductType ProductType { get; set; }
    }
}
