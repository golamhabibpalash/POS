using BLL.IManagers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APP.Utilities.Components
{
    public class ProductTypesViewComponent : ViewComponent
    {
        private readonly IProductTypeManager _productTypeManager;
        public ProductTypesViewComponent(IProductTypeManager productTypeManager)
        {
            _productTypeManager = productTypeManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var productTypeList = await _productTypeManager.GetAllAsync();
            return View();
        }
    }
}
