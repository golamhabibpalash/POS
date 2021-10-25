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
    public class SuppliersController : Controller
    {
        private readonly ISupplierManager _supplierManager;

        public SuppliersController(ISupplierManager supplierManager)
        {
            _supplierManager = supplierManager;
        }

        // GET: Suppliers
        public async Task<IActionResult> Index()
        {
            return View(await _supplierManager.GetAllAsync());
        }

        // GET: Suppliers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supplier = await _supplierManager.GetByIdAsync((int)id);
            if (supplier == null)
            {
                return NotFound();
            }

            return View(supplier);
        }

        // GET: Suppliers/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SupplierName,Phone,Email,Image,Address,Id,CreatedBy,CreatedAt,UpdatedBy,UpdatedAt")] Supplier supplier)
        {
            if (ModelState.IsValid)
            {
                await _supplierManager.AddAsync(supplier);
                return RedirectToAction(nameof(Index));
            }
            return View(supplier);
        }

        // GET: Suppliers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supplier = await _supplierManager.GetByIdAsync((int)id);
            if (supplier == null)
            {
                return NotFound();
            }
            return View(supplier);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SupplierName,Phone,Email,Image,Address,Id,CreatedBy,CreatedAt,UpdatedBy,UpdatedAt")] Supplier supplier)
        {
            if (id != supplier.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {

                    await _supplierManager.UpdateAsync(supplier);
                }
                catch (DbUpdateConcurrencyException)
                {
                    bool supplierExists = await _supplierManager.GetByIdAsync(id)!=null;
                    if (!supplierExists)
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
            return View(supplier);
        }

        // GET: Suppliers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supplier = await _supplierManager.GetByIdAsync((int)id);
            if (supplier == null)
            {
                return NotFound();
            }

            return View(supplier);
        }

        // POST: Suppliers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _supplierManager.RemoveAsync(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
