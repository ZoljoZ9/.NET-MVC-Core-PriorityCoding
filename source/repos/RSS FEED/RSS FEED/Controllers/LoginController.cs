
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RSS_FEED.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace RSS_FEED.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILogger<LoginController> _logger;
        private readonly IdentityModel db;
        public LoginController(ILogger<LoginController> logger, IdentityModel context)
        {
            _logger = logger;
            db = context;
        }
        public IActionResult Loginuser()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(Login obj)
        {
            try
            {
                if (db.login.Any(a => a.Email == obj.Email && a.Password == obj.Password))
                {
                    TempData["user"] = obj.Email;
                    return RedirectToAction("Loginuser");
                }

                else
                {
                    ViewBag.error = "!!Please Enter valid login credentials.";
                }
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                ViewBag.error = "!!There is some error.";
            }
            return View();
        }

       
    }
}
