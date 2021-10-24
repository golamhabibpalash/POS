using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APP.VIewModels.CategoryVM
{
    public class CategoryCreateVM
    {
        [Display(Name = "Name")]
        public string CategoryName { get; set; }

        [Display(Name = "Icon")]
        public IFormFile CategoryIcon { get; set; }

        [Display(Name = "Category")]
        public int? CategoryId { get; set; }
    }
}
