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
    public class SalesController : Controller
    {
        private readonly ISaleManager _saleManager;

        public SalesController(ISaleManager saleManager)
        {
            _saleManager = saleManager;
        }

        // GET: Sales
        public async Task<IActionResult> Index()
        {
            return View(await _saleManager.GetAllAsync());
        }

        // GET: Sales/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sale = await _saleManager.GetByIdAsync((int)id);

            if (sale == null)
            {
                return NotFound();
            }

            return View(sale);
        }

        // GET: Sales/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SaleCode,SaleDate,Id,CreatedBy,CreatedAt,UpdatedBy,UpdatedAt")] Sale sale)
        {
            if (ModelState.IsValid)
            {
                await _saleManager.AddAsync(sale);
                return RedirectToAction(nameof(Index));
            }
            return View(sale);
        }

        // GET: Sales/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sale = await _saleManager.GetByIdAsync((int)id);
            if (sale == null)
            {
                return NotFound();
            }
            return View(sale);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SaleCode,SaleDate,Id,CreatedBy,CreatedAt,UpdatedBy,UpdatedAt")] Sale sale)
        {
            if (id != sale.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _saleManager.UpdateAsync(sale);
                }
                catch (DbUpdateConcurrencyException)
                {
                    bool saleExits = await _saleManager.GetByIdAsync(id) != null;
                    if (!saleExits)
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
            return View(sale);
        }

        // GET: Sales/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sale = await _saleManager.GetByIdAsync((int)id);
            if (sale == null)
            {
                return NotFound();
            }

            return View(sale);
        }

        // POST: Sales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _saleManager.RemoveAsync(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
