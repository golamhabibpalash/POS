using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODELS
{
    public class UnitOfMeasure : CommonProps
    {
        [Display(Name ="Measurement Unit")]
        public string UnitName { get; set; }
        public string Description { get; set; }
    }
}
