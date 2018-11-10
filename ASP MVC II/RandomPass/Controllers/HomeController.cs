using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace RandomPass.Controllers {

    public class HomeController : Controller {
        private static Random rand = new Random();


        // GET: /Home/
        [HttpGet]
        [Route ("")]
        public IActionResult Index () {
            int? Count =  HttpContext.Session.GetInt32("Count");
            if(Count is null)
            {
                Count = 1;
                ViewBag.Count = Count;
                ViewBag.Pass = Generator();
            }
            else
            {
                Count += 1;
                ViewBag.Count = Count;
                ViewBag.Pass = Generator();
            }
            HttpContext.Session.SetInt32("Count", (int) Count);


            // var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            // Random rand = new Random();
            // var String = new char[15];
            // var Count = 0;
            // for(var i = 0; i < String.Length; i ++){
            //     String[i] = chars[rand.Next(chars.Length)];
            // }
            // var RandomString = new string(String);
            // HttpContext.Session.SetString("random1", RandomString);
            // string randomVal =  HttpContext.Session.GetString("random1");
            
            return View ();
        }

        public string Generator()
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            Random rand = new Random();
            var String = new char[15];
            for(var i = 0; i < String.Length; i ++){
                String[i] = chars[rand.Next(chars.Length)];
            }
            var RandomString = new string(String);
            return RandomString;
        }

    }
}