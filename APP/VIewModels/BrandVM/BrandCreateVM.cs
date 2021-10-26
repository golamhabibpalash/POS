using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APP.ViewModels.BrandVM
{
    public class BrandCreateVM
    {
        [Display(Name = "Name")]
        public string BrandName { get; set; }
        public IFormFile Logo { get; set; }

        [Display(Name = "Category")]
        public int CategoryId { get; set; }
    }
}
