using Microsoft.AspNetCore.Mvc;

namespace HelloASP.Controllers
{
    public class PortfolioController : Controller
    {
        // [HttpGet ("")]

        // public IActionResult Index ()
        // {
        //     return View(); 
        // }

        // Requests
        // localhost: 5000
        [Route("")]
        [HttpGet]
        public string Index()
        {
            return "This is my Index"; 
        }

        [HttpGet("projects")]
        public string Project()
        {
            return "These are my projects"; 
        }

        [HttpGet("contact")]
        public string Contact()
        {
            return "This is my contact"; 
        }
    }
}