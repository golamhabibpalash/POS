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
    public class PurchaseDetailsController : Controller
    {
        
        private readonly IPurchaseDetailManager _purchaseDetailManager;
        private readonly IProductManager _productManager;
        private readonly IPurchaseManager _purchaseManager;
        public PurchaseDetailsController(IPurchaseDetailManager purchaseDetailManager, IProductManager productManager, IPurchaseManager purchaseManager)
        {
            _purchaseDetailManager = purchaseDetailManager;
            _productManager = productManager;
            _purchaseManager = purchaseManager;
        }

        // GET: PurchaseDetails
        public async Task<IActionResult> Index()
        {
            return View(await _purchaseDetailManager.GetAllAsync());
        }

        // GET: PurchaseDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var purchaseDetail = await _purchaseDetailManager.GetByIdAsync((int)id);
            if (purchaseDetail == null)
            {
                return NotFound();
            }

            return View(purchaseDetail);
        }

        // GET: PurchaseDetails/Create
        public async Task<IActionResult> Create()
        {
            ViewData["ProductId"] = new SelectList(await _productManager.GetAllAsync(), "Id", "ProductName");
            ViewData["PurchaseId"] = new SelectList(await _purchaseManager.GetAllAsync(), "Id", "PurchaseCode");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductId,PurchaseQty,Price,Discount,PurchaseId,Id,CreatedBy,CreatedAt,UpdatedBy,UpdatedAt")] PurchaseDetail purchaseDetail)
        {
            if (ModelState.IsValid)
            {

                await _purchaseDetailManager.AddAsync(purchaseDetail);
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProductId"] = new SelectList(await _productManager.GetAllAsync(), "Id", "ProductName", purchaseDetail.ProductId);
            ViewData["PurchaseId"] = new SelectList(await _purchaseManager.GetAllAsync(), "Id", "PurchaseCode", purchaseDetail.PurchaseId);
            return View(purchaseDetail);
        }

        // GET: PurchaseDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var purchaseDetail = await _purchaseDetailManager.GetByIdAsync((int)id);
            if (purchaseDetail == null)
            {
                return NotFound();
            }
            ViewData["ProductId"] = new SelectList(await _productManager.GetAllAsync(), "Id", "Id", purchaseDetail.ProductId);
            ViewData["PurchaseId"] = new SelectList(await _purchaseManager.GetAllAsync(), "Id", "Id", purchaseDetail.PurchaseId);
            return View(purchaseDetail);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductId,PurchaseQty,Price,Discount,PurchaseId,Id,CreatedBy,CreatedAt,UpdatedBy,UpdatedAt")] PurchaseDetail purchaseDetail)
        {
            if (id != purchaseDetail.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {

                    await _purchaseDetailManager.UpdateAsync(purchaseDetail);
                }
                catch (DbUpdateConcurrencyException)
                {
                    bool PurchaseDetailExists = await _purchaseDetailManager.GetByIdAsync(id)!=null;
                    if (!PurchaseDetailExists)
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
            ViewData["ProductId"] = new SelectList(await _productManager.GetAllAsync(), "Id", "Id", purchaseDetail.ProductId);
            ViewData["PurchaseId"] = new SelectList(await _purchaseManager.GetAllAsync(), "Id", "Id", purchaseDetail.PurchaseId);
            return View(purchaseDetail);
        }

        // GET: PurchaseDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var purchaseDetail = await _purchaseDetailManager.GetByIdAsync((int)id);
            if (purchaseDetail == null)
            {
                return NotFound();
            }

            return View(purchaseDetail);
        }

        // POST: PurchaseDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _purchaseDetailManager.RemoveAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
