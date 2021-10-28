using BLL.IManagers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APP.Controllers
{
    public class SupplierTypesController : Controller
    {
        public SupplierTypesController(ISupplierTypeManager supplierTypeManager)
        {

        }

        public ActionResult Index()
        {

            return View();
        }

        // GET: SupplierTypesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SupplierTypesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SupplierTypesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SupplierTypesController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SupplierTypesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SupplierTypesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SupplierTypesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
