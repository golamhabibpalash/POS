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
    public class ProductsController : Controller
    {
        private readonly IProductManager _productManager;
        private readonly IBrandManager _brandManager;
        private readonly ICategoryManager _categoryManager;
        private readonly IProductColorManager _productColorManager;
        private readonly IProductSizeManager _productSizeManager;
        private readonly IProductTypeManager _productTypeManager;
        private readonly IUnitOfMeasureManager _unitOfMeasureManager;
        public ProductsController(IProductManager productManager, IBrandManager brandManager, ICategoryManager categoryManager, IProductColorManager productColorManager, IProductSizeManager productSizeManager, IProductTypeManager productTypeManager, IUnitOfMeasureManager unitOfMeasureManager)
        {
            _productManager = productManager;
            _brandManager = brandManager;
            _categoryManager = categoryManager;
            _productColorManager = productColorManager;
            _productSizeManager = productSizeManager;
            _productTypeManager = productTypeManager;
            _unitOfMeasureManager = unitOfMeasureManager;
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
            var prods = await _productManager.GetAllAsync();
            return View(prods);
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _productManager.GetByIdAsync((int)id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Products/Create
        public async Task<IActionResult> Create()
        {
            ViewData["BrandId"] = new SelectList(await _brandManager.GetAllAsync(), "Id", "BrandName");
            ViewData["CategoryId"] = new SelectList(await _categoryManager.GetAllAsync(), "Id", "CategoryName");
            ViewData["ProductColorId"] = new SelectList(await _productColorManager.GetAllAsync(), "Id", "ColorName");
            ViewData["ProductSizeId"] = new SelectList(await _productSizeManager.GetAllAsync(), "Id", "SizeName");
            ViewData["ProductTypeId"] = new SelectList(await _productTypeManager.GetAllAsync(), "Id", "TypeName");
            ViewData["UnitOfMeasureId"] = new SelectList(await _unitOfMeasureManager.GetAllAsync(), "Id", "UnitName"); 
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductName,Image,BarCode,AlertQty,UoM,ManufacturingDate,ExpiryDate,UnitPurchasePrice,UnitSellingPrice,BrandId,CategoryId,ProductTypeId,IsAvailable,Description,ProductColorId,ProductSizeId,Id,CreatedBy,CreatedAt,UpdatedBy,UpdatedAt")] Product product)
        {
            if (ModelState.IsValid)
            {
                await _productManager.AddAsync(product);
                return RedirectToAction(nameof(Index));
            }
            ViewData["BrandId"] = new SelectList(await _brandManager.GetAllAsync(), "Id", "BrandName", product.BrandId);
            ViewData["CategoryId"] = new SelectList(await _categoryManager.GetAllAsync(), "Id", "CategoryName", product.CategoryId);
            ViewData["ProductColorId"] = new SelectList(await _productColorManager.GetAllAsync(), "Id", "ColorName", product.ProductColorId);
            ViewData["ProductSizeId"] = new SelectList(await _productSizeManager.GetAllAsync(), "Id", "SizeName", product.ProductSizeId);
            ViewData["ProductTypeId"] = new SelectList(await _productTypeManager.GetAllAsync(), "Id", "TypeName", product.ProductTypeId);
            ViewData["UnitOfMeasureId"] = new SelectList(await _unitOfMeasureManager.GetAllAsync(), "Id", "UnitName", product.UnitOfMeasureId);
            return View(product);
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _productManager.GetByIdAsync((int)id);
            if (product == null)
            {
                return NotFound();
            }
            ViewData["BrandId"] = new SelectList(await _brandManager.GetAllAsync(), "Id", "BrandName", product.BrandId);
            ViewData["CategoryId"] = new SelectList(await _categoryManager.GetAllAsync(), "Id", "CategoryName", product.CategoryId);
            ViewData["ProductColorId"] = new SelectList(await _productColorManager.GetAllAsync(), "Id", "ColorName", product.ProductColorId);
            ViewData["ProductSizeId"] = new SelectList(await _productSizeManager.GetAllAsync(), "Id", "SizeName", product.ProductSizeId);
            ViewData["ProductTypeId"] = new SelectList(await _productTypeManager.GetAllAsync(), "Id", "TypeName", product.ProductTypeId);
            ViewData["UnitOfMeasureId"] = new SelectList(await _unitOfMeasureManager.GetAllAsync(), "Id", "UnitName", product.UnitOfMeasureId);
            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductName,Image,BarCode,AlertQty,UoM,ManufacturingDate,ExpiryDate,UnitPurchasePrice,UnitSellingPrice,BrandId,CategoryId,ProductTypeId,IsAvailable,Description,ProductColorId,ProductSizeId,Id,CreatedBy,CreatedAt,UpdatedBy,UpdatedAt")] Product product)
        {
            if (id != product.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {

                    await _productManager.UpdateAsync(product);
                }
                catch (DbUpdateConcurrencyException)
                {
                    bool productExits = await _productManager.GetByIdAsync(product.Id) != null;
                    if (!productExits)
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
            ViewData["BrandId"] = new SelectList(await _brandManager.GetAllAsync(), "Id", "BrandName", product.BrandId);
            ViewData["CategoryId"] = new SelectList(await _categoryManager.GetAllAsync(), "Id", "CategoryName", product.CategoryId);
            ViewData["ProductColorId"] = new SelectList(await _productColorManager.GetAllAsync(), "Id", "ColorName", product.ProductColorId);
            ViewData["ProductSizeId"] = new SelectList(await _productSizeManager.GetAllAsync(), "Id", "SizeName", product.ProductSizeId);
            ViewData["ProductTypeId"] = new SelectList(await _productTypeManager.GetAllAsync(), "Id", "TypeName", product.ProductTypeId);
            ViewData["UnitOfMeasureId"] = new SelectList(await _unitOfMeasureManager.GetAllAsync(), "Id", "UnitName", product.UnitOfMeasureId);
            return View(product);
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _productManager.GetByIdAsync((int)id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {

            await _productManager.RemoveAsync(id);
            return RedirectToAction(nameof(Index));
        }

        
    }
}
