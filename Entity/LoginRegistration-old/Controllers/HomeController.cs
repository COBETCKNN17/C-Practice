using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LoginRegistration.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;

namespace LoginRegistration.Controllers
{
    public class HomeController : Controller
    {
        private readonly DataContext _context; 

        public HomeController (DataContext context)
        {
            _context = context; 
        }
       
       [HttpGet ("")]
        public IActionResult Index () {
            return View ();
        }

        [HttpPost]
        [Route("register")]
        public IActionResult Register(User user)
        {
            if(_context.users.SingleOrDefault(p => p.Email == user.Email) != null)
            {
                var error = new User {};
                TempData["Error"] = error; 
                return View("Index", TempData["Error"]); 
            }

            if (ModelState.IsValid)
            {
                PasswordHasher<User> Hasher = new PasswordHasher<User>();
                user.Password = Hasher.HashPassword(user, user.Password);
                _context.users.Add(user); 
                _context.SaveChanges(); 
                System.Console.Write("User created...", user.FirstName); 
                HttpContext.Session.SetInt32("UserId", user.UserId);
                return RedirectToAction("Welcome"); 
            }
            else
            {
                return View("Index"); 
            } 
        }

        [HttpGet ("welcome")]
        public IActionResult Welcome () {
            User theUser = _context.users.SingleOrDefault(p => p.UserId == HttpContext.Session.GetInt32("UserId"));
            ViewBag.User = theUser; 
            return View ();
        }

        [HttpGet]
        [Route("logout")]
        public IActionResult Logout()
        {
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("loginpage")]
        public IActionResult LoginPage()
        {
            return View("Login");
        }

        [HttpPost]
        [Route("login")]
        public IActionResult Login(Login userSubmission)
        {
            if (ModelState.IsValid)
            {
                System.Console.Write("ModelState is Valid"); 
                var theUser = _context.users.FirstOrDefault(u => u.Email == userSubmission.Email); 
                System.Console.Write("theUser", theUser);
                System.Console.Write("login user", userSubmission); 
                if(theUser != null && userSubmission.Password != null)
                {
                   var Hash = new PasswordHasher<Login>();
                   // check login password with database password of theUser match 
                   var check = Hash.VerifyHashedPassword(userSubmission, theUser.Password, userSubmission.Password); 
                    System.Console.Write("check", check); 
                   if(check != 0)
                   {
                       HttpContext.Session.SetInt32("UserId", theUser.UserId);
                       return RedirectToAction("Welcome"); 
                   }
                }
                if (theUser == null){
                    ModelState.AddModelError("Email", "Invalid Email/Password");
                }
                var error = new Login { };
                TempData["Error"] = error;
                return View("Login", TempData["Error"]);
            }
            else 
            {
                 return View("Login");
            }
        }
    }
}
