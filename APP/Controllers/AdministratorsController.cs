using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APP.Controllers
{
    public class AdministratorsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
