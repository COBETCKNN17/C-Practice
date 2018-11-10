using Microsoft.AspNetCore.Http; 
using Microsoft.AspNetCore.Mvc; 

namespace TimeDisplay.Controllers 
{
    public class TimeDisplayController : Controller 
    {
        [HttpGet("")]
        public IActionResult Index()
        {
            return View("Index"); 
        }
    }
}