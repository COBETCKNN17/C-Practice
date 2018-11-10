using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DojoSurvey_Model.Models; 

namespace DojoSurvey_Model.Controllers {
    public class DojoController : Controller {
        [HttpGet("")]
        public IActionResult Index () {
            return View ("Index");
        }   

        [HttpPost("submit_survey")]
        public IActionResult UserFormSubmit(string  name, string location, string language, string comments)
        {
            Survey survey = new Survey{
                name = name,
                location = location,
                language = language,
                comments = comments
            };
            return View("Result", survey);
        }

        [HttpGet("gobackbutton")]
        public IActionResult GoBack () {
            return View ("Index");
        }   
    }
}