﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODELS
{
    public class Sale : CommonProps
    {
        [Display(Name = "Code")]
        public string SaleCode { get; set; }
        public string Remark { get; set; }

        [Display(Name = "Date")]
        public DateTime SaleDate { get; set; }

        public List<SaleDetail> SaleDetails { get; set; }
    }
}
