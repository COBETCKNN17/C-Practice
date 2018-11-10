using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System;

namespace RandomPasscode.Controllers 
{
    public class HomeController : Controller 
    {
        [HttpGet("")]
        public IActionResult Index()
        {
            int? Count = HttpContext.Session.GetInt32("Count");
            if (Count == null) 
            {
                Count = 1; 
            }
             var random = new Random();
            var possible_characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var characters_string = new char[14];

            for (int i=0; i < characters_string.Length; i++)
            {
                characters_string[i] = possible_characters[random.Next(characters_string.Length)]; 
            }

            var random_string = new String(characters_string); 
            ViewBag.Result = random_string;
            ViewBag.Count = Count; 
            return View();
        }

        [HttpPost("generate")]
        public IActionResult Generate()
        {
            int? Count = HttpContext.Session.GetInt32("Count");
            HttpContext.Session.SetInt32("Count", (int)Count + 1);
            int? newCount = HttpContext.Session.GetInt32("passcode");
            ViewBag.Count = newCount; 
            
            var random = new Random();
            var possible_characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var characters_string = new char[14];

            for (int i=0; i < characters_string.Length; i++)
            {
                characters_string[i] = possible_characters[random.Next(characters_string.Length)]; 
            }

            var random_string = new String(characters_string); 
            ViewBag.Result = random_string;
           
            return View();
        }
    }
}