using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APP.Controllers
{
    public class AdministratorsController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AdministratorsController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public IActionResult UserList()
        {
           
            return View();
        }
    }
}
