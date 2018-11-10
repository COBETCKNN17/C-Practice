using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Configuration; 
using ViewModelFun.Models; 

namespace ViewModelFun.Controllers {
    public class ViewModelFunController : Controller {
        [HttpGet ("")]
        public IActionResult Index () {
            string greeting = "Greetings from the Controller.";
            return View ("Index", greeting);

        }

        [Route ("numbers")]
        public IActionResult numbers () {
            int[] arr = { 1, 2, 3, 10, 43, 5 };
            return View ("Numbers", arr);
        }

        [Route ("users")]
        public IActionResult Names () {
            string[] names = new string[] {
                "Sally",
                "Billy",
                "Joey",
                "Moose"
            };
            return View ("Users", names);
        }


        [HttpGet ("user")]
        public IActionResult user () {
            User newUser = new User()
            {
                FirstName = "Felix",
                LastName = "Markman"
            };  
            return View ("User", newUser);
        }
    }
}