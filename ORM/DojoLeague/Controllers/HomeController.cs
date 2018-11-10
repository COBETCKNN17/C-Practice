using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using DojoLeague.Models;
using DojoLeague.Factories;  

namespace DojoLeague.Controllers
{
    public class HomeController : Controller
    {
        private readonly DojoFactory dojoFactory;
        private readonly NinjaFactory ninjaFactory;  
        public HomeController()
        {
            dojoFactory = new DojoFactory(); 
            ninjaFactory = new NinjaFactory(); 
        }

        [HttpGet]
        [Route ("")]
        public IActionResult Index()
        {
            ViewBag.Dojos = dojoFactory.getAllDojos(); 
            ViewBag.Ninjas = ninjaFactory.getAllNinjas(); 
            System.Console.WriteLine("retrieved table"); 
            return View(); 
        }
        [HttpPost("create_dojo")]
        public IActionResult DojoCreate(Dojo dojo){
            dojoFactory.create_dojo(dojo);
            return RedirectToAction("Index"); 
        }
    }
}
