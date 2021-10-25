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
    public class PurchasesController : Controller
    {
        private readonly IPurchaseManager _purchaseManager;
        private readonly ISupplierManager _supplierManager;

        public PurchasesController(IPurchaseManager purchaseManager, ISupplierManager supplierManager)
        {
            _purchaseManager = purchaseManager;
            _supplierManager = supplierManager;
        }

        // GET: Purchases
        public async Task<IActionResult> Index()
        {
            
            return View(await _purchaseManager.GetAllAsync());
        }

        // GET: Purchases/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var purchase = await _purchaseManager.GetByIdAsync((int)id);
            if (purchase == null)
            {
                return NotFound();
            }

            return View(purchase);
        }

        // GET: Purchases/Create
        public async Task<IActionResult> Create()
        {
            ViewData["SupplierId"] = new SelectList(await _purchaseManager.GetAllAsync(), "Id", "PurchaseCode");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PurchaseCode,PurchaseDate,SupplierId,PurchaseAmount,Id,CreatedBy,CreatedAt,UpdatedBy,UpdatedAt")] Purchase purchase)
        {
            if (ModelState.IsValid)
            {
                await _purchaseManager.AddAsync(purchase);
                return RedirectToAction(nameof(Index));
            }
            ViewData["SupplierId"] = new SelectList(await _supplierManager.GetAllAsync(), "Id", "SupplierName", purchase.SupplierId);
            return View(purchase);
        }

        // GET: Purchases/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var purchase = await _purchaseManager.GetByIdAsync((int)id);
            if (purchase == null)
            {
                return NotFound();
            }
            ViewData["SupplierId"] = new SelectList(await _supplierManager.GetAllAsync(), "Id", "SupplierName", purchase.SupplierId);
            return View(purchase);
        }

        // POST: Purchases/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PurchaseCode,PurchaseDate,SupplierId,PurchaseAmount,Id,CreatedBy,CreatedAt,UpdatedBy,UpdatedAt")] Purchase purchase)
        {
            if (id != purchase.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _purchaseManager.AddAsync(purchase);
                }
                catch (DbUpdateConcurrencyException)
                {
                    bool PurchaseExists = await _purchaseManager.GetByIdAsync(id)!=null;
                    if (!PurchaseExists)
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
            ViewData["SupplierId"] = new SelectList(await _supplierManager.GetAllAsync(), "Id", "SupplierName", purchase.SupplierId);
            return View(purchase);
        }

        // GET: Purchases/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var purchase = await _purchaseManager.GetByIdAsync((int)id);
            if (purchase == null)
            {
                return NotFound();
            }

            return View(purchase);
        }

        // POST: Purchases/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {

            await _purchaseManager.RemoveAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
