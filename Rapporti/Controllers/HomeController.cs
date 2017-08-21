using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Rapporti.Models;
using Microsoft.AspNetCore.Identity;

namespace Rapporti.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserManager<Utente> _manager;
        public HomeController(UserManager<Utente> manager)
        {
            _manager = manager;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            if(User.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Rapporti");
            return RedirectToAction("Login", "Account");
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
