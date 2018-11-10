using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DojoSurvey.Controllers {
    public class DojoSurveyController : Controller {
        [HttpGet("")]
        public IActionResult Index () {
            return View ("Index");
        }   

        [HttpPost("userformsubmit")]
        public IActionResult UserFormSubmit(string  username, string location, string language, string comments)
        {
            ViewBag.username = username;
            ViewBag.location = location; 
            ViewBag.language = language; 
            ViewBag.comments = comments;
            return View("Result");
        }

        [HttpGet("gobackbutton")]
        public IActionResult GoBack () {
            return View ("Index");
        }   
    }
}