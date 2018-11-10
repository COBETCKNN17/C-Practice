using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LoginRegistration.Data;
using LoginRegistration.Models;
using Microsoft.AspNetCore.Http;

namespace LoginRegistration.Controllers
{
    public class HomeController : Controller
    {
        public DataContext _context;
        public HomeController(DataContext context)
        {
            _context = context;
        }

        [HttpGet ("welcome")]
        public IActionResult Welcome() {
            User theUser = _context.Users.SingleOrDefault(p => p.UserId == HttpContext.Session.GetInt32("UserId"));
            ViewBag.User = theUser; 
            return View ();
        }

        [HttpGet]
        [Route("logout")]
        public IActionResult Logout()
        {
            return RedirectToAction ("LoginPage", "Auth");
        }
    }
}
