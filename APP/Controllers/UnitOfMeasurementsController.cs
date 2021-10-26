using BLL.IManagers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MODELS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APP.Controllers
{
    public class UnitOfMeasurementsController : Controller
    {
        private readonly IUnitOfMeasureManager _unitOfMeasureManager;

        public UnitOfMeasurementsController(IUnitOfMeasureManager unitOfMeasureManager)
        {
            _unitOfMeasureManager = unitOfMeasureManager;
        }
        // GET: UnitOfMeasurementsController
        public ActionResult Index()
        {
            return View();
        }

        // GET: UnitOfMeasurementsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UnitOfMeasurementsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UnitOfMeasurementsController/Create
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

        // GET: UnitOfMeasurementsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UnitOfMeasurementsController/Edit/5
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

        // GET: UnitOfMeasurementsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UnitOfMeasurementsController/Delete/5
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

        public async Task<JsonResult> CreateByJson(UnitOfMeasure model)
        {
            if (ModelState.IsValid)
            {
                model.CreatedAt = DateTime.Now;
                model.CreatedBy = HttpContext.Session.GetString("UserId");
                await _unitOfMeasureManager.AddAsync(model);
                return Json("");
            }
            return Json("");
        }
    }
}
