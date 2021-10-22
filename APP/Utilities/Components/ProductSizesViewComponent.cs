using BLL.IManagers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APP.Utilities.Components
{
    public class ProductSizesViewComponent : ViewComponent
    {
        private readonly IProductSizeManager _productSizeManager;

        public ProductSizesViewComponent(IProductSizeManager productSizeManager)
        {
            _productSizeManager = productSizeManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var colors = await _productSizeManager.GetAllAsync();
            return View();
        }
    }
}
