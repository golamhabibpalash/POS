using APP.ViewModels.BrandVM;
using APP.ViewModels.CategoryVM;
using AutoMapper;
using MODELS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APP.Utilities.AutoMapper
{
    public class AutoMapperConfiguration:Profile
    {
        public AutoMapperConfiguration()
        {
            CreateMap<Category, CategoryCreateVM>();
            CreateMap<CategoryCreateVM, Category>();

            CreateMap<Brand, BrandCreateVM>();
            CreateMap<BrandCreateVM, Brand>();
        }
    }
}
