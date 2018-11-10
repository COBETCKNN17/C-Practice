using System;
using System.Collections.Generic;
using System.Linq;
using LoginRegistration.Controllers;
using LoginRegistration.Data;
using LoginRegistration.Models;
using LoginRegistration.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LoginRegistration.Controllers {
    public class AuthController : Controller {
        public DataContext _context;
        public AuthController (DataContext context) {
            _context = context;
        }

        [HttpGet]
        [Route ("")]
        public IActionResult Index () {
            return View ("Register");
        }

        [HttpPost ("Register")]
        public IActionResult Register (RegistrationViewModel reg) {
            if (!ModelState.IsValid) {
                return View ();
            } else {
                var User = _context.Users.FirstOrDefault (user => user.Email == reg.Email);
                if (User != null) {
                    TempData["Error"] = "This email address has already been used to register.";
                    System.Console.Write ("Temp Error");
                    return View ();
                } else {
                    PasswordHasher<RegistrationViewModel> Hasher = new PasswordHasher<RegistrationViewModel> ();
                    string hashedPassword = Hasher.HashPassword (reg, reg.Password);
                    User newUser = new User {
                        FirstName = reg.FirstName,
                        LastName = reg.LastName,
                        Email = reg.Email,
                        Password = hashedPassword,
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now
                    };
                    _context.Add (newUser);
                    _context.SaveChanges ();
                    HttpContext.Session.SetInt32 ("UserId", newUser.UserId);
                    return RedirectToAction ("Welcome", "Home");
                }

            }
        }

        [HttpPost ("Login")]
        public IActionResult Login (LoginModel login) {
            System.Console.Write ("inside login");
            if (!ModelState.IsValid) {
                System.Console.Write ("invalid model");
                return View ();
            } else {
                System.Console.Write ("Model State is Valid");
                PasswordHasher<LoginModel> Hasher = new PasswordHasher<LoginModel> ();
                var theUser = _context.Users.FirstOrDefault (u => u.Email == login.Email);
                System.Console.Write ("the User: ", theUser);
                System.Console.Write ("the User's Password: ", theUser.Password);
                if (theUser != null && login.Password != null) {
                    var check = Hasher.VerifyHashedPassword (login, theUser.Password, login.Password);
                    if (check != 0) {
                        HttpContext.Session.SetInt32 ("UserId", theUser.UserId);
                        return RedirectToAction ("Welcome", "Home");
                    } else {
                        ModelState.AddModelError ("Password", "The user name or password provided is incorrect");
                        return View ();
                    }
                }
                return View ();
            }
        }

        [HttpGet ("LoginPage")]
        public IActionResult LoginPage () {
            return View ("Login");
        }

        [HttpGet ("Registration")]
        public IActionResult Registration () {
            return View ("Register");
        }

    }
}