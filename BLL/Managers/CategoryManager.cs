using BLL.IManagers;
using DAL.IRepositories;
using MODELS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BLL.Managers
{
    public class CategoryManager : Manager<Category>, ICategoryManager
    {
        public CategoryManager(ICategoryRepository Repository) : base(Repository)
        {

        }
        public override async Task<bool> AddAsync(Category model)
        {
            var AllCategories = await _repository.GetAllAsync();
            var cat = AllCategories.Where(c => c.CategoryName.Trim() == model.CategoryName.Trim()).FirstOrDefault();
            if (cat!=null)
            {
                return false;
            }
            return await _repository.AddAsync(model);
        }
    }
}
