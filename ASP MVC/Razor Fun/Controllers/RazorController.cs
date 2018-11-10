using Microsoft.AspNetCore.Mvc;

namespace Razon_Fun.Controllers {
    public class RazorController : Controller {
        [HttpGet] 
        [Route ("")] 
        public IActionResult Index () {
            return View ("Index");
        }
    }
}