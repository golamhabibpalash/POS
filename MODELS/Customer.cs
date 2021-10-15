using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODELS
{
    public class Customer : CommonProps
    {
        [Display(Name="Name")]
        public string CustomerName { get; set; }

        [Display(Name = "Phone")]
        public string PhoneNo { get; set; }
        public string Email { get; set; }

        [Display(Name = "Photo")]
        public string CustomerPhoto { get; set; }
    }
}
