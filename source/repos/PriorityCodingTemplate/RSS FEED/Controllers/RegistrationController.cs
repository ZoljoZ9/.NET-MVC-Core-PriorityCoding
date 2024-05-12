using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RSS_FEED.Models;


namespace RSS_FEED.Controllers
{
    public class RegistrationController : Controller
    {
        private readonly ILogger<RegistrationController> _logger;
        private readonly IdentityModel db;
        public RegistrationController(ILogger<RegistrationController> logger, IdentityModel context)
        {
            _logger = logger;
            db = context;
        }
        public IActionResult Registration()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Registration(Login obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.login.Add(obj);
                    db.SaveChanges();
                    ViewBag.success = "Sign Up successfully.";
                    return View();
                }
                else
                {
                    ViewBag.error = "!!There is some error.";
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

