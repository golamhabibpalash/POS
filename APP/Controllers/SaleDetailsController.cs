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
    public class SaleDetailsController : Controller
    {
        private readonly ISaleDetailManager _saleDetailManager;
        private readonly IProductManager _productManager;
        private readonly ICustomerManager _customerManager;
        private readonly ISaleManager _saleManager;


        public SaleDetailsController(ISaleDetailManager saleDetailManager, IProductManager productManager, ICustomerManager customerManager, ISaleManager saleManager)
        {
            _saleDetailManager = saleDetailManager;
            _productManager = productManager;
            _customerManager = customerManager;
            _saleManager = saleManager;
        }

        // GET: SaleDetails
        public async Task<IActionResult> Index()
        {
            return View(await _saleDetailManager.GetAllAsync());
        }

        // GET: SaleDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var saleDetail = await _saleDetailManager.GetByIdAsync((int)id);
            if (saleDetail == null)
            {
                return NotFound();
            }

            return View(saleDetail);
        }

        // GET: SaleDetails/Create
        public async Task<IActionResult> Create()
        {
            ViewData["CustomerId"] = new SelectList(await _customerManager.GetAllAsync(), "Id", "CustomerName");
            ViewData["ProductId"] = new SelectList(await _productManager.GetAllAsync(), "Id", "ProductName");
            ViewData["SaleId"] = new SelectList(await _saleManager.GetAllAsync(), "Id", "SaleCode");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SaleId,ProductId,SaleQty,CustomerId,Id,CreatedBy,CreatedAt,UpdatedBy,UpdatedAt")] SaleDetail saleDetail)
        {
            if (ModelState.IsValid)
            {
                await _saleDetailManager.AddAsync(saleDetail);
                return RedirectToAction(nameof(Index));
            }
            ViewData["CustomerId"] = new SelectList(await _customerManager.GetAllAsync(), "Id", "CustomerName", saleDetail.CustomerId);
            ViewData["ProductId"] = new SelectList(await _productManager.GetAllAsync(), "Id", "ProductName", saleDetail.ProductId);
            ViewData["SaleId"] = new SelectList(await _saleManager.GetAllAsync(), "Id", "SaleCode", saleDetail.SaleId);
            return View(saleDetail);
        }

        // GET: SaleDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var saleDetail = await _saleDetailManager.GetByIdAsync((int)id);
            if (saleDetail == null)
            {
                return NotFound();
            }
            ViewData["CustomerId"] = new SelectList(await _customerManager.GetAllAsync(), "Id", "CustomerName", saleDetail.CustomerId);
            ViewData["ProductId"] = new SelectList(await _productManager.GetAllAsync(), "Id", "ProductName", saleDetail.ProductId);
            ViewData["SaleId"] = new SelectList(await _saleManager.GetAllAsync(), "Id", "SaleCode", saleDetail.SaleId);
            return View(saleDetail);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SaleId,ProductId,SaleQty,CustomerId,Id,CreatedBy,CreatedAt,UpdatedBy,UpdatedAt")] SaleDetail saleDetail)
        {
            if (id != saleDetail.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {

                    await _saleDetailManager.UpdateAsync(saleDetail);
                }
                catch (DbUpdateConcurrencyException)
                {
                    bool SaleDetailExists = await _saleDetailManager.GetByIdAsync(id) != null;
                    if (!SaleDetailExists)
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
            ViewData["CustomerId"] = new SelectList(await _customerManager.GetAllAsync(), "Id", "CustomerName", saleDetail.CustomerId);
            ViewData["ProductId"] = new SelectList(await _productManager.GetAllAsync(), "Id", "ProductName", saleDetail.ProductId);
            ViewData["SaleId"] = new SelectList(await _saleManager.GetAllAsync(), "Id", "SaleCode", saleDetail.SaleId);
            return View(saleDetail);
        }

        // GET: SaleDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var saleDetail = await _saleDetailManager.GetByIdAsync((int)id);
            if (saleDetail == null)
            {
                return NotFound();
            }

            return View(saleDetail);
        }

        // POST: SaleDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _saleDetailManager.RemoveAsync(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
