using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DB;
using MODELS;
using BLL.IManagers;
using Microsoft.AspNetCore.Http;

namespace APP.Controllers
{
    public class ProductTypesController : Controller
    {
        private readonly IProductTypeManager _productTypeManager;

        public ProductTypesController(IProductTypeManager productTypeManager)
        {
            _productTypeManager = productTypeManager;
        }

        // GET: ProductTypes
        public async Task<IActionResult> Index()
        {
            return View(await _productTypeManager.GetAllAsync());
        }

        // GET: ProductTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productType = await _productTypeManager.GetByIdAsync((int)id);
            if (productType == null)
            {
                return NotFound();
            }

            return View(productType);
        }

        // GET: ProductTypes/Create
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TypeName,Id,Description")] ProductType productType)
        {
            if (ModelState.IsValid)
            {
                productType.CreatedAt = DateTime.Now;
                productType.CreatedBy = HttpContext.Session.GetString("UserId");

                await _productTypeManager.AddAsync(productType);
                return RedirectToAction(nameof(Index));
            }
            return View(productType);
        }

        // GET: ProductTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productType = await _productTypeManager.GetByIdAsync((int)id);
            if (productType == null)
            {
                return NotFound();
            }
            return View(productType);
        }

     
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TypeName,Description,Id")] ProductType productType)
        {
            if (id != productType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    productType.UpdatedAt = DateTime.Now;
                    productType.UpdatedBy = HttpContext.Session.GetString("UserId");

                    bool isUpdated = await _productTypeManager.UpdateAsync(productType);
                    if (isUpdated == false)
                    {
                        return View();
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    ProductType productType1 = await _productTypeManager.GetByIdAsync(id);
                    if (productType1==null)
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(productType);
        }

        // GET: ProductTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productType = await _productTypeManager.GetByIdAsync((int)id);
            if (productType == null)
            {
                return NotFound();
            }

            return View(productType);
        }

        // POST: ProductTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _productTypeManager.RemoveAsync(id);
            return RedirectToAction(nameof(Index));
        }

        public async Task<JsonResult> CreateByJson(ProductType productType)
        {
            if (ModelState.IsValid)
            {
                productType.CreatedAt = DateTime.Now;
                productType.CreatedBy = HttpContext.Session.GetString("UserId");
                await _productTypeManager.AddAsync(productType);
                return Json("");
            }
            return Json("");
        }

    }
}
