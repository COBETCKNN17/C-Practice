using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using FormSubmission.Models;

namespace formsubmission.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            ViewBag.Errors = new List<string>(); 
            return View();
        }


        [HttpPost]
        [Route("/dashboard")]
        public IActionResult dashboard()
        {
            return View("dashboard");
        }

        [HttpPost]
        [Route("register")]
        public IActionResult ValidateUser(string firstname, string lastname, int age, string email, string password)
            {


                Console.WriteLine("======================================================");
                Console.WriteLine("Inbound FirstName: "+firstname);
                Console.WriteLine("Inbound LastName: "+lastname);
                Console.WriteLine("Inbound Age: "+age);
                Console.WriteLine("Inbound Email: "+email);
                Console.WriteLine("Inbound Password: "+password);
                Console.WriteLine("======================================================");

                User NewUser = new User
                {
                    FirstName = firstname,
                    LastName = lastname,
                    Age = age,
                    Email = email,
                    Password = password
                };

                TryValidateModel(NewUser); // Runs our validations
                if(ModelState.IsValid){
                    return View("dashboard");
                } else {
                    ViewBag.Errors = ModelState.Values;
                    return View("index");
                }
            }

    }
}