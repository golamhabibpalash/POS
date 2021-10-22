using BLL.IManagers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APP.Utilities.Components
{
    public class ProductColorsViewComponent : ViewComponent
    {
        private readonly IProductColorManager _productColorManager;

        public ProductColorsViewComponent(IProductColorManager productColorManager)
        {
            _productColorManager = productColorManager;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var colors = await _productColorManager.GetAllAsync();
            return View();
        }

    }
}
