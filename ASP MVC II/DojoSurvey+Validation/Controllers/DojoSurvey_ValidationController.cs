using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DojoSurvey_Validation.Models; 

namespace DojoSurvey_ValidationControllers 
{
    public class DojoSurvey_ValidationController : Controller
    {
        [HttpGet ("")]
        public IActionResult Index () {
            return View ("Index");
        }

        [HttpPost ("userformsubmit")]
        public IActionResult UserFormSubmit (string username, string location, string language, string comments) {
            Survey survey = new Survey {
                Username = username,
                Location = location,
                Language = language,
                Comments = comments
            };

            Console.WriteLine("======================================================");
            Console.WriteLine("Inbound Name: " + username);
            Console.WriteLine("Inbound Location: "+ location);
            Console.WriteLine("Inbound Language: "+ language);
            Console.WriteLine("Inbound Comments: "+ comments);
            Console.WriteLine("======================================================");

            TryValidateModel (survey);
            if (ModelState.IsValid) {
                return View ("Result", survey);
            }
            else {
                // ViewBag.Errors = ModelState.Values;
                return View("index");
            }
        }

        [HttpGet ("gobackbutton")]
        public IActionResult GoBack () {
            return View ("Index");
        }
    }
}