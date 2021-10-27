using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODELS
{
    public class ProductSize : CommonProps
    {
        [Display(Name="Size Name")]
        public string SizeName { get; set; }

        [Display(Name ="Short Name")]
        public string ShortName { get; set; }
        public string Description { get; set; }
    }
}
