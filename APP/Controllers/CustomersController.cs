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
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace APP.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ICustomerManager _customerManager;
        private readonly IWebHostEnvironment _host;

        public CustomersController(ICustomerManager customerManager, IWebHostEnvironment host)
        {
            _customerManager = customerManager;
            _host = host;
        }

        // GET: Customers
        public async Task<IActionResult> Index()
        {
            return View(await _customerManager.GetAllAsync());
        }

        // GET: Customers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _customerManager.GetByIdAsync((int)id);

            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // GET: Customers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CustomerName,PhoneNo,Email,CustomerPhoto,Id,CreatedBy,CreatedAt,UpdatedBy,UpdatedAt")] Customer customer, IFormFile cPhoto)
        {
            if (ModelState.IsValid)
            {
                string fileName = "";
                if (cPhoto!=null)
                {
                    fileName = "Customer_" + Guid.NewGuid() + Path.GetExtension(cPhoto.FileName);
                    var f = Path.Combine(_host.WebRootPath, "images/Customer", fileName);
                    using (var stream = new FileStream(f,FileMode.CreateNew))
                    {
                        await cPhoto.CopyToAsync(stream);
                    }
                    customer.CustomerPhoto = fileName;
                }
                customer.CreatedAt = DateTime.Now;
                customer.CreatedBy = HttpContext.Session.GetString("UserId");

                await _customerManager.AddAsync(customer);
                return RedirectToAction(nameof(Index));
            }
            return View(customer);
        }

        // GET: Customers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _customerManager.GetByIdAsync((int)id);
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CustomerName,PhoneNo,Email,CustomerPhoto,Id,CreatedBy,CreatedAt,UpdatedBy,UpdatedAt")] Customer customer)
        {
            if (id != customer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _customerManager.UpdateAsync(customer);
                }
                catch (DbUpdateConcurrencyException)
                {
                    bool customerExist = (await _customerManager.GetByIdAsync(customer.Id)!=null);

                    if (!customerExist)
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
            return View(customer);
        }

        // GET: Customers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _customerManager.GetByIdAsync((int)id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {

            await _customerManager.RemoveAsync(id);
            return RedirectToAction(nameof(Index));
        }

        
    }
}
