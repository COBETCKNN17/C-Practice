using Microsoft.AspNetCore.Mvc;
using System; 

namespace HelloASP.Controllers
{
    public class HomeController : Controller
    {
        // [HttpGet ("")]

        // public IActionResult Index ()
        // {
        //     return View(); 
        // }

        // Requests
        // localhost: 5000
        // [Route("")]
        // [HttpGet]
        // public string Index()
        // {
        //     return "Hello from Index, watching"; 
        // }

        // localhost: 5000/hello 
        [HttpGet("hello")]

        //public RedirectResult Hello()
        public IActionResult Hello()
        {
            // localhost:5000 
            Console.WriteLine("Hello There, redirecting...."); 
            // var param = new{username="Felix", location="Chicago"} // pass the param into redirecttoaction 
            // or use anonymous object inside function arguments 
            return RedirectToAction("HelloUser", new{username="Felix", location="Chicago"}); 
        }

        // localhost:5000/users/???
        [HttpGet("users/{username}/{location}")]
        // public string HelloUser(string username, string location)
        // {
        //     if(location == "Chicago")
        //         return $"Hello {username} from Chicago {location}";
        //     return $"Hello {username} from {location}"; 
        // }
        public IActionResult HelloUser(string username, string location)
        {
            var response = new{user=username, place=location}; 
            // var stringArray = new string[]
            // {
            //     "Felix", "This", "Is", "Example"
            // }; 
            if(location == "Seattle")
                return Json(response);
            else if(location == "Chicago")
                return View("Index"); 
            return RedirectToAction("Index"); 
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            // Home/HiThere.cshtml
            // Home/Shared/HiThere.cshtml
            return View(); 
        }
    }
}