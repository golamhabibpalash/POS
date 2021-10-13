using Entity;
using Manager.IContacts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Controllers
{
    public class ProductsController : Controller
    {
        public IProductManager productManager;
        public async Task<IActionResult> Index()
        {
            List<Product> products = await productManager.GetAllAsync();
            return View(products);
        }
        public async Task<IActionResult> Details(int id)
        {
            Product product = await productManager.GetByIdAsync(id);
            return View();
        }
        public async Task<IActionResult> Create(Product model)
        {
            if (ModelState.IsValid)
            {
                await productManager.Add(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }
    }
}
