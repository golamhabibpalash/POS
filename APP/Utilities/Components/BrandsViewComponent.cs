using BLL.IManagers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP.Utilities.Components
{
    public class BrandsViewComponent:ViewComponent
    {
        private readonly IBrandManager _brandManager;
        private readonly ICategoryManager _categoryManager;

        public BrandsViewComponent(IBrandManager brandManager, ICategoryManager categoryManager)
        {
            _brandManager = brandManager;
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
