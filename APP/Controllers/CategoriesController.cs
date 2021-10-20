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
        private readonly POSDbContext _context;
        private readonly ICategoryManager _categoryManager;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public CategoriesController(POSDbContext context, ICategoryManager categoryManager, IMapper mapper, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _categoryManager = categoryManager;
            _mapper = mapper;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: Categories
        public async Task<IActionResult> Index()
        {
            return View(await _context.Categories.ToListAsync());
        }

        // GET: Categories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _context.Categories
                .FirstOrDefaultAsync(m => m.Id == id);
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
        public async Task<IActionResult> Create([Bind("CategoryName,CategoryIcon,ParentCategory,Id,CreatedBy,CreatedAt,UpdatedBy,UpdatedAt")] Category category)
        {
            if (ModelState.IsValid)
            {
                _context.Add(category);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
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

            var category = await _context.Categories.FindAsync(id);
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
                    _context.Update(category);
                    await _context.SaveChangesAsync();
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

            var category = await _context.Categories
                .FirstOrDefaultAsync(m => m.Id == id);
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
            var category = await _context.Categories.FindAsync(id);
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CategoryExists(int id)
        {
            return _context.Categories.Any(e => e.Id == id);
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
                    string logoName = "category_"+cat.Id+"_"+cat.CategoryName.Trim();
                    string f = Path.Combine(root, folder, logoName);
                    using (var stream = new FileStream(f, FileMode.Create))
                    {
                        await category.CategoryIcon.CopyToAsync(stream);
                    }
                    cat.CategoryIcon = logoName;
                }
                bool isSaved = await _categoryManager.AddAsync(cat);
                var catList = await _categoryManager.GetAllAsync();
                if (isSaved==true)
                {
                    return Json(catList, new { isSaved = true });
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
