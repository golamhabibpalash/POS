using BLL.IManagers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APP.Utilities.Components
{
    public class CategoriesViewComponent : ViewComponent
    {
        private readonly ICategoryManager _categoryManager;

        public CategoriesViewComponent(ICategoryManager categoryManager)
        {
            _categoryManager = categoryManager;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var categories = await _categoryManager.GetAllAsync();
            ViewBag.CategoryList = new SelectList(categories, "Id", "CategoryName");
            return View();
        }
    }
}
