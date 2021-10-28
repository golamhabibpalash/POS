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
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace APP.Controllers
{
    public class SuppliersController : Controller
    {
        private readonly ISupplierManager _supplierManager;
        private readonly ISupplierTypeManager _supplierTypeManager;
        private readonly IWebHostEnvironment _host;

        public SuppliersController(ISupplierManager supplierManager, ISupplierTypeManager supplierTypeManager, IWebHostEnvironment host)
        {
            _supplierManager = supplierManager;
            _supplierTypeManager = supplierTypeManager;
            _host = host;
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
        public async Task<IActionResult> Create()
        {
            ViewBag.SupplierList = new SelectList(await _supplierTypeManager.GetAllAsync(), "Id", "SupplierTypeName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SupplierName,Phone,Email,Image,Address,SupplierTypeId,SupplierType,Id,CreatedBy,CreatedAt,UpdatedBy,UpdatedAt")] Supplier supplier, IFormFile supplierImage)
        {
            if (ModelState.IsValid)
            {
                if (supplierImage!=null)
                {
                    var root = _host.WebRootPath;
                    var folder = "images/Supplier";
                    var imageName = "Supplier_"+Guid.NewGuid()+Path.GetExtension(supplierImage.FileName);
                    var combine = Path.Combine(root, folder, imageName);
                    using (var stream = new FileStream(combine,FileMode.Create))
                    {
                        await supplierImage.CopyToAsync(stream);
                    }

                    supplier.Image = imageName;

                }
                supplier.CreatedAt = DateTime.Now;
                supplier.CreatedBy = HttpContext.Session.GetString("UserId");
                await _supplierManager.AddAsync(supplier);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.SupplierList = new SelectList(await _supplierTypeManager.GetAllAsync(), "Id", "SupplierTypeName", supplier.SupplierTypeId);
            return View(supplier);
        }

        // GET: Suppliers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            ViewBag.SupplierList = new SelectList(await _supplierTypeManager.GetAllAsync(), "Id", "SupplierTypeName");
            var supplier = await _supplierManager.GetByIdAsync((int)id);
            if (supplier == null)
            {
                return NotFound();
            }
            return View(supplier);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SupplierName,Phone,Email,Image,Address,SupplierTypeId,SupplierType,Id,CreatedBy,CreatedAt,UpdatedBy,UpdatedAt")] Supplier supplier)
        {
            if (id != supplier.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    supplier.UpdatedAt = DateTime.Now;
                    supplier.UpdatedBy = HttpContext.Session.GetString("UserId");
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
            ViewBag.SupplierList = new SelectList(await _supplierTypeManager.GetAllAsync(), "Id", "SupplierTypeName", supplier.SupplierTypeId);
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
