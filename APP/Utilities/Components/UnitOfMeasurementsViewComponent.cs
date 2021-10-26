using BLL.IManagers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APP.Utilities.Components
{
    public class UnitOfMeasurementsViewComponent : ViewComponent
    {
        private readonly IUnitOfMeasureManager _unitOfMeasureManager;

        public UnitOfMeasurementsViewComponent(IUnitOfMeasureManager unitOfMeasureManager)
        {
            _unitOfMeasureManager = unitOfMeasureManager;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var list = await _unitOfMeasureManager.GetAllAsync(); 
            return View();
        }
    }
}
