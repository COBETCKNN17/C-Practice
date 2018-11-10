using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Dojodachi.Models;
using Microsoft.AspNetCore.Http;

namespace Dojodachi.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            if (HttpContext.Session.GetObjectFromJson<Dachi>("dojodachi2")==null)
            {
                HttpContext.Session.SetObjectAsJson("dojodachi2", new Dachi());
            }
            ViewBag.Dachi = HttpContext.Session.GetObjectFromJson<Dachi>("dojodachi2");
            ViewBag.Message = "You got new Dachi";
            ViewBag.GameStatus = "running";
            ViewBag.Reaction = "";
            return View();
        }
        [HttpPost]
        [Route("Action")]
        public IActionResult Action(string action)
        {
            Dachi dachi = HttpContext.Session.GetObjectFromJson<Dachi>("dojodachi2");
            Random rand = new Random();
            ViewBag.GameStatus = "running";
            switch(action)
            {
                case "feed":
                    if (dachi.Meals > 0)
                    {
                        dachi.Meals--;
                        if (rand.Next(0, 4) > 0)
                        {
                            dachi.Fullness += rand.Next(5, 11);
                            ViewBag.Reaction = ":)";
                            ViewBag.Message = "Food is good!";
                        }
                        else
                        {
                            ViewBag.Reaction = ":(";
                            ViewBag.Message = "Food not good!";
                        }
                    }
                    else
                    {
                        ViewBag.Reaction = ":(";
                        ViewBag.Message = "No food!";
                    }
                    break;
                case "play":
                    if (dachi.Energy > 0)
                    {
                        dachi.Energy -= 5;
                        if (rand.Next(0, 4) > 0)
                        {
                            dachi.Happiness += rand.Next(5, 11);
                            ViewBag.Reaction = ":)";
                            ViewBag.Message = "Play is good!";
                        }
                        else
                        {
                            ViewBag.Reaction = ":(";
                            ViewBag.Message = "Play not good!";
                        }
                    }
                    else
                    {
                        ViewBag.Reaction = ":(";
                        ViewBag.Message = "No energy!";
                    }
                    break;
                case "work":
                    if (dachi.Energy > 4)
                    {
                        dachi.Energy -= 5;
                        dachi.Meals += rand.Next(1, 4);
                        ViewBag.Reaction = ":)";
                        ViewBag.Message = "You got some meals!";
                    }
                    else
                    {
                        ViewBag.Reaction = ":(";
                        ViewBag.Message = "No energy!";
                    }
                    break;  
                case "sleep":
                    dachi.Energy += 15;
                    dachi.Fullness -= 5;
                    dachi.Happiness -= 5;
                    ViewBag.Reaction = ":)";
                    ViewBag.Message = "Rested!";
                    break;
                default:
                    ViewBag.Reaction = "???????";
                    ViewBag.Message = "Whhhhat haaaaappened!";
                    break;
            }
            if (dachi.Fullness < 1 || dachi.Happiness < 1)
            {
                ViewBag.Message = "Dachi failed";
                ViewBag.GameStatus = "over";
                ViewBag.Reaction = ":(";
            }
            else if (dachi.Fullness > 99 || dachi.Happiness > 99)
            {
                ViewBag.Message = "Dachi won";
                ViewBag.GameStatus = "over";
                ViewBag.Reaction = ":)";
            }
            HttpContext.Session.SetObjectAsJson("dojodachi2", dachi);
            ViewBag.Dachi = dachi;
            return View("Index");
        }

        [HttpGet]
        [Route("reset")]
        public IActionResult Reset()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
    }
}