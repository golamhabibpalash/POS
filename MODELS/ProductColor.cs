using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODELS
{
    public class ProductColor : CommonProps
    {
        [Display(Name = "Color Name")]
        public string ColorName { get; set; }

        [Display(Name = "Code")]
        public string ColorCode { get; set; }
    }
}
