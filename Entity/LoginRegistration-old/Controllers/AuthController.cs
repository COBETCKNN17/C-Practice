using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using LoginRegistration.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using LoginRegistration.ViewModels; 

namespace LoginRegistration.Controllers {
    public class AuthController : Controller {
        
        private readonly DataContext _context; 

        public AuthController (DataContext context)
        {
            _context = context; 
        }

        [HttpGet ("")]
        public IActionResult Index () {
            return View ();
        }
        
        [HttpGet ("register")]
        public IActionResult Registration (RegistrationViewModel reg) {
            if (!ModelState.IsValid)
            {
                PasswordHasher<RegistrationViewModel> Hasher = new PasswordHasher<RegistrationViewModel>();
                string hashedPassword = Hasher.HashPassword(reg, reg.Password); 
                reg.Password = Hasher.HashPassword(reg, reg.Password);
                User newUser = new User {
                    FirstName = reg.FirstName,
                    LastName = reg.LastName,
                    Email = reg.Email,
                    Password = hashedPassword,
                    CreatedAt = DateTime.Now, 
                    UpdtedAt = DateTime.Now
                };
                _context.Add(newUser);
                _context.SaveChanges();          
                return View ();
            }
            return View ();
        }
    }

}