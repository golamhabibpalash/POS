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
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using APP.VIewModels.BrandVM;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace APP.Controllers
{
    public class BrandsController : Controller
    {
        private readonly IBrandManager _brandManager;
        private readonly ICategoryManager _categoryManager;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public BrandsController(IBrandManager brandManager, ICategoryManager categoryManager, IMapper mapper, IWebHostEnvironment webHostEnvironment)
        {
            _brandManager = brandManager;
            _categoryManager = categoryManager;
            _mapper = mapper;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: Brands
        public async Task<IActionResult> Index()
        {
            return View(await _brandManager.GetAllAsync());
        }

        // GET: Brands/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var brand = await _brandManager.GetByIdAsync((int)id);
            if (brand == null)
            {
                return NotFound();
            }

            return View(brand);
        }

        // GET: Brands/Create
        public async Task<IActionResult> Create()
        {
            ViewData["CategoryId"] = new SelectList(await _brandManager.GetAllAsync(), "Id", "BrandName");
            return View();
        }

        // POST: Brands/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BrandName,Logo,CategoryId,Id,CreatedBy,CreatedAt,UpdatedBy,UpdatedAt")] BrandCreateVM brandVM)
        {
            if (ModelState.IsValid)
            {
                Brand brand = _mapper.Map<Brand>(brandVM);

                if (brandVM.Logo!=null)
                {
                    string logoName = "brand_"+Guid.NewGuid()+brandVM.BrandName+Path.GetExtension(brandVM.Logo.FileName);
                    var f = Path.Combine(_webHostEnvironment.WebRootPath,"Images/Brand/", logoName);
                    using (var stream = new FileStream(f,FileMode.Create))
                    {
                        await brandVM.Logo.CopyToAsync(stream);
                    }

                    brand.Logo = logoName;
                }
                brand.CreatedBy = HttpContext.Session.GetString("UserId");
                brand.CreatedAt = DateTime.Now; 
                await _brandManager.AddAsync(brand);
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(await _brandManager.GetAllAsync(), "Id", "BrandName", brandVM.CategoryId);
            return View(brandVM);
        }

        // GET: Brands/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var brand = await _brandManager.GetByIdAsync((int)id);
            if (brand == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(await _brandManager.GetAllAsync(), "Id", "BrandName", brand.CategoryId);
            return View(brand);
        }

        // POST: Brands/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BrandName,Logo,CategoryId,Id,CreatedBy,CreatedAt,UpdatedBy,UpdatedAt")] Brand brand)
        {
            if (id != brand.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _brandManager.UpdateAsync(brand);
                }
                catch (DbUpdateConcurrencyException)
                {
                    bool BrandExists=false;
                    Brand br = await _brandManager.GetByIdAsync(id);
                    if (br!=null)
                    {
                        BrandExists = true;
                    }
                    if (BrandExists==false)
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
            ViewData["CategoryId"] = new SelectList(await _brandManager.GetAllAsync(), "Id", "BrandName", brand.CategoryId);
            return View(brand);
        }

        // GET: Brands/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var brand = await _brandManager.GetByIdAsync((int)id);
            if (brand == null)
            {
                return NotFound();
            }

            return View(brand);
        }

        // POST: Brands/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {

            await _brandManager.RemoveAsync(id);
            return RedirectToAction(nameof(Index));
        }
        public async Task<JsonResult> CreateByJson(BrandCreateVM brandVM)
        {
            if (ModelState.IsValid)
            {
                Brand brand = _mapper.Map<Brand>(brandVM);

                if (brandVM.Logo != null)
                {
                    string logoName = "brand_" + Guid.NewGuid() + brandVM.BrandName + Path.GetExtension(brandVM.Logo.FileName);
                    var f = Path.Combine(_webHostEnvironment.WebRootPath, "Images/Brand/", logoName);
                    using (var stream = new FileStream(f, FileMode.Create))
                    {
                        await brandVM.Logo.CopyToAsync(stream);
                    }

                    brand.Logo = logoName;
                }
                brand.CreatedAt = DateTime.Now;
                brand.CreatedBy = HttpContext.Session.GetString("UserId");
                await _brandManager.AddAsync(brand);
                return Json("");
            }            
            return Json("");
        }
    }
}
