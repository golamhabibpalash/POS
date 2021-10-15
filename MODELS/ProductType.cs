using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODELS
{
    public class ProductType : CommonProps
    {
        [Display(Name = "Type Name")]
        public string TypeName { get; set; }

    }
}
