using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODELS
{
    public class Category : CommonProps
    {
        [Display(Name = "Name")]
        public string CategoryName { get; set; }

        [Display(Name = "Icon")]
        public string CategoryIcon { get; set; }

        [Display(Name = "Category")]
        public int ParentCategory { get; set; }

        public List<Product> Products { get; set; }
        public List<Brand> Brands { get; set; }
    }
}
