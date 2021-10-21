using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODELS
{
    public class Category : CommonProps
    {
        [Display(Name = "Name"), Required]
        public string CategoryName { get; set; }

        [Display(Name = "Icon")]
        public string CategoryIcon { get; set; }

        [Display(Name = "Category")]
        public int? CategoryId { get; set; }
        public Category Parent { get; set; }

        public virtual ICollection<Category> Children { get; set; }
        public List<Product> Products { get; set; }
        public List<Brand> Brands { get; set; }
    }
}
