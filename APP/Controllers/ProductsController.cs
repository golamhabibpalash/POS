using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DB;
using MODELS;

namespace APP.Controllers
{
    public class ProductsController : Controller
    {
        private readonly POSDbContext _context;
        public ProductsController(POSDbContext context)
        {
            _context = context;
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
            var pOSDbContext = _context.Products.Include(p => p.Brand).Include(p => p.Category).Include(p => p.ProductColor).Include(p => p.ProductSize).Include(p => p.ProductType);
            return View(await pOSDbContext.ToListAsync());
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.Brand)
                .Include(p => p.Category)
                .Include(p => p.ProductColor)
                .Include(p => p.ProductSize)
                .Include(p => p.ProductType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            ViewData["BrandId"] = new SelectList(_context.Brands, "Id", "BrandName");
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "CategoryName");
            ViewData["ProductColorId"] = new SelectList(_context.ProductColors, "Id", "ColorName");
            ViewData["ProductSizeId"] = new SelectList(_context.productSizes, "Id", "SizeName");
            ViewData["ProductTypeId"] = new SelectList(_context.ProductTypes, "Id", "TypeName");
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductName,Image,BarCode,AlertQty,UoM,ManufacturingDate,ExpiryDate,UnitPurchasePrice,UnitSellingPrice,BrandId,CategoryId,ProductTypeId,IsAvailable,Description,ProductColorId,ProductSizeId,Id,CreatedBy,CreatedAt,UpdatedBy,UpdatedAt")] Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BrandId"] = new SelectList(_context.Brands, "Id", "BrandName", product.BrandId);
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "CategoryName", product.CategoryId);
            ViewData["ProductColorId"] = new SelectList(_context.ProductColors, "Id", "ColorName", product.ProductColorId);
            ViewData["ProductSizeId"] = new SelectList(_context.productSizes, "Id", "SizeName", product.ProductSizeId);
            ViewData["ProductTypeId"] = new SelectList(_context.ProductTypes, "Id", "TypeName", product.ProductTypeId);
            return View(product);
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            ViewData["BrandId"] = new SelectList(_context.Brands, "Id", "BrandName", product.BrandId);
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "CategoryName", product.CategoryId);
            ViewData["ProductColorId"] = new SelectList(_context.ProductColors, "Id", "ColorName", product.ProductColorId);
            ViewData["ProductSizeId"] = new SelectList(_context.productSizes, "Id", "SizeName", product.ProductSizeId);
            ViewData["ProductTypeId"] = new SelectList(_context.ProductTypes, "Id", "TypeName", product.ProductTypeId);
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
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
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.Id))
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
            ViewData["BrandId"] = new SelectList(_context.Brands, "Id", "BrandName", product.BrandId);
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "CategoryName", product.CategoryId);
            ViewData["ProductColorId"] = new SelectList(_context.ProductColors, "Id", "ColorName", product.ProductColorId);
            ViewData["ProductSizeId"] = new SelectList(_context.productSizes, "Id", "SizeName", product.ProductSizeId);
            ViewData["ProductTypeId"] = new SelectList(_context.ProductTypes, "Id", "TypeName", product.ProductTypeId);
            return View(product);
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.Brand)
                .Include(p => p.Category)
                .Include(p => p.ProductColor)
                .Include(p => p.ProductSize)
                .Include(p => p.ProductType)
                .FirstOrDefaultAsync(m => m.Id == id);
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
            var product = await _context.Products.FindAsync(id);
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.Id == id);
        }
    }
}
