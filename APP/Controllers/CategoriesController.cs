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
using APP.VIewModels.CategoryVM;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace APP.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ICategoryManager _categoryManager;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public CategoriesController(ICategoryManager categoryManager, IMapper mapper, IWebHostEnvironment webHostEnvironment)
        {
            _categoryManager = categoryManager;
            _mapper = mapper;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: Categories
        public async Task<IActionResult> Index()
        {
            return View(await _categoryManager.GetAllAsync());
        }

        // GET: Categories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _categoryManager.GetByIdAsync((int)id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // GET: Categories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Categories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( CategoryCreateVM category)
        {
            if (ModelState.IsValid)
            {
                Category cat = _mapper.Map<Category>(category);
                if (category.CategoryIcon != null)
                {
                    string root = _webHostEnvironment.WebRootPath;
                    string folder = "Images/Category/";
                    string logoName = "category_" + Guid.NewGuid() + "_" + cat.CategoryName.Trim() + Path.GetExtension(category.CategoryIcon.FileName);
                    string f = Path.Combine(root, folder, logoName);
                    using (var stream = new FileStream(f, FileMode.Create))
                    {
                        await category.CategoryIcon.CopyToAsync(stream);
                    }
                    cat.CategoryIcon = logoName;
                }
                cat.CreatedAt = DateTime.Now;
                cat.CreatedBy = HttpContext.Session.GetString("UserId");

                bool isSaved = await _categoryManager.AddAsync(cat);
                if (isSaved == true)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.msg = category.CategoryName + " is already exist";
                    return View(category);
                }
                
            }
            return View(category);
        }

        // GET: Categories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _categoryManager.GetByIdAsync((int)id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        // POST: Categories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CategoryName,CategoryIcon,ParentCategory,Id,CreatedBy,CreatedAt,UpdatedBy,UpdatedAt")] Category category)
        {
            if (id != category.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _categoryManager.UpdateAsync(category);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoryExists(category.Id))
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
            return View(category);
        }

        // GET: Categories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _categoryManager.GetByIdAsync((int)id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // POST: Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {

            await _categoryManager.RemoveAsync(id);
            return RedirectToAction(nameof(Index));
        }

        private bool CategoryExists(int id)
        {
            var cat = _categoryManager.GetByIdAsync(id);
            return cat != null? false:true;

        }

        [HttpPost]
        public async Task<JsonResult> CreateByJson(CategoryCreateVM category)
        {
            if (ModelState.IsValid)
            {
                Category cat = _mapper.Map<Category>(category);
                if (category.CategoryIcon!=null)
                {
                    string root = _webHostEnvironment.WebRootPath;
                    string folder = "Images/Category/";
                    string logoName = "category_"+Guid.NewGuid()+"_"+cat.CategoryName.Trim()+Path.GetExtension(category.CategoryIcon.FileName);
                    string f = Path.Combine(root, folder, logoName);
                    using (var stream = new FileStream(f, FileMode.Create))
                    {
                        await category.CategoryIcon.CopyToAsync(stream);
                    }
                    cat.CategoryIcon = logoName;
                }
                cat.CreatedAt = DateTime.Now;
                cat.CreatedBy = HttpContext.Session.GetString("UserId");

                bool isSaved = await _categoryManager.AddAsync(cat);
                var catList = await _categoryManager.GetAllAsync();
                if (isSaved==true)
                {
                    //return Json(catList, new { isSaved = true });
                    return Json("");
                }
                else
                {
                    return Json(new { isSaved = false});
                }
            }
            return Json("");
        }
    }
}
