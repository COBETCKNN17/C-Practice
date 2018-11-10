using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using LoginRegistration.ViewModels;
using LoginRegistration.Data;
using Microsoft.AspNetCore.Identity;
using LoginRegistration.Models;

namespace LoginRegistration.Controllers
{
    public class AuthController : Controller
    {
        public DataContext _context;
        public AuthController(DataContext context)
        {
            _context = context;
        }

        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("register")]
        public IActionResult Registration()
        {
            return View();
        }

        [HttpPost("register")]
        public IActionResult Registration(RegistrationViewModel reg)
        {
            if(!ModelState.IsValid)
            {
                return View();
            }
            else
            {
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
                _context.Add(newUser);
                _context.SaveChanges();
                return View("Index");
            }
        }

        public IActionResult Login()
        {
            return View();
        }
    }
}
