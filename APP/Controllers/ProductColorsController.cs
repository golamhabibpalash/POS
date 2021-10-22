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

namespace APP.Controllers
{
    public class ProductColorsController : Controller
    {
        private readonly IProductColorManager _productColorManager;

        public ProductColorsController(IProductColorManager productColorManager)
        {
            _productColorManager = productColorManager;
        }

        // GET: ProductColors
        public async Task<IActionResult> Index()
        {
            return View(await _productColorManager.GetAllAsync());
        }

        // GET: ProductColors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productColor = await _productColorManager.GetByIdAsync((int)id);
            if (productColor == null)
            {
                return NotFound();
            }

            return View(productColor);
        }

        // GET: ProductColors/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ColorName,ColorCode,Id,CreatedBy,CreatedAt,UpdatedBy,UpdatedAt")] ProductColor productColor)
        {
            if (ModelState.IsValid)
            {
                
                await _productColorManager.AddAsync(productColor);
                return RedirectToAction(nameof(Index));
            }
            return View(productColor);
        }

        // GET: ProductColors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productColor = await _productColorManager.GetByIdAsync((int)id);
            if (productColor == null)
            {
                return NotFound();
            }
            return View(productColor);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ColorName,ColorCode,Id,CreatedBy,CreatedAt,UpdatedBy,UpdatedAt")] ProductColor productColor)
        {
            if (id != productColor.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _productColorManager.UpdateAsync(productColor);
                }
                catch (DbUpdateConcurrencyException)
                {
                    var productExist = await _productColorManager.GetByIdAsync(productColor.Id) != null;
                    if (!productExist)
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
            return View(productColor);
        }

        // GET: ProductColors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productColor = await _productColorManager.GetByIdAsync((int)id);
            if (productColor == null)
            {
                return NotFound();
            }

            return View(productColor);
        }

        // POST: ProductColors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {

            await _productColorManager.RemoveAsync(id);
            return RedirectToAction(nameof(Index));
        }

        
    }
}
