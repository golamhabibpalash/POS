using BLL.IManagers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APP.Utilities.Components
{
    public class SuppliersViewComponent : ViewComponent
    {
        private readonly ISupplierTypeManager _supplierTypeManager;
        public SuppliersViewComponent(ISupplierTypeManager supplierTypeManager)
        {
            _supplierTypeManager = supplierTypeManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            ViewBag.SupplierTypeList = new SelectList(await _supplierTypeManager.GetAllAsync(), "Id", "SupplierTypeName");
            return View();
        }
    }
}
