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
    public class ProductSizesController : Controller
    {
        private readonly IProductSizeManager _productSiseManager;
        public ProductSizesController(IProductSizeManager productSizeManager)
        {
            _productSiseManager = productSizeManager;
        }

        // GET: ProductSizes
        public async Task<IActionResult> Index()
        {
            return View(await _productSiseManager.GetAllAsync());
        }

        // GET: ProductSizes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productSize = await _productSiseManager.GetByIdAsync((int)id);
            if (productSize == null)
            {
                return NotFound();
            }

            return View(productSize);
        }

        // GET: ProductSizes/Create
        public IActionResult Create()
        {
            return View();
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CreatedBy,CreatedAt,UpdatedBy,UpdatedAt")] ProductSize productSize)
        {
            if (ModelState.IsValid)
            {

                await _productSiseManager.AddAsync(productSize);
                return RedirectToAction(nameof(Index));
            }
            return View(productSize);
        }

        // GET: ProductSizes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productSize = await _productSiseManager.GetByIdAsync((int)id);
            if (productSize == null)
            {
                return NotFound();
            }
            return View(productSize);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CreatedBy,CreatedAt,UpdatedBy,UpdatedAt")] ProductSize productSize)
        {
            if (id != productSize.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {

                    await _productSiseManager.UpdateAsync(productSize);
                }
                catch (DbUpdateConcurrencyException)
                {
                    bool ProductSizeExists = await _productSiseManager.GetByIdAsync(id)!=null;
                    if (!ProductSizeExists)
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
            return View(productSize);
        }

        // GET: ProductSizes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productSize = await _productSiseManager.GetByIdAsync((int)id);
            if (productSize == null)
            {
                return NotFound();
            }

            return View(productSize);
        }

        // POST: ProductSizes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {

            await _productSiseManager.RemoveAsync(id);
            return RedirectToAction(nameof(Index));
        }

        
    }
}
