using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Crudelicious.Models;
using Microsoft.AspNetCore.Mvc;

namespace Crudelicious.Controllers {
    public class HomeController : Controller {
        private CrudeliciousContext dbContext;
        public HomeController (CrudeliciousContext context) {
            dbContext = context;
        }

        [HttpGet ("")]
        public IActionResult Index () {
            List<Dish> allDishes = dbContext.dishes.ToList ();
            System.Console.WriteLine ("retrieved dishes...");
            System.Console.WriteLine (allDishes);
            ViewBag.Dishes = allDishes;
            return View ();
        }

        [HttpGet ("New")]
        public IActionResult New () {
            return View ("New");
        }

        [HttpGet("{Id}")]
        public IActionResult ShowDish(int id)
        {
            Dish returnedDish = dbContext.dishes.FirstOrDefault(d => d.DashId == id);
            System.Console.Write("Dish retrieved.." + returnedDish);
            ViewBag.ShownDish = returnedDish; 
            return View(); 
        }

        [HttpPost ("Create")]
        public IActionResult Create (Dish dish) 
        {
            // Dish newDish = new Dish {
            //     Name = dish.Name,
            //     Chef = dish.Chef,
            //     Description = dish.Description,
            //     Tastiness = dish.Tastiness,
            //     Calories = dish.Calories,
            //     CreatedAt = DateTime.Now,
            //     UpdatedAt = DateTime.Now
            // };

            dbContext.Add (dish);
            dbContext.SaveChanges ();
            System.Console.WriteLine ("create a dish...");
            System.Console.WriteLine (dish);
            return RedirectToAction ("Index");
        }

        [HttpGet("Delete/{Id}")]
        public IActionResult Delete (int id)
        {
            Dish returnedDish = dbContext.dishes.FirstOrDefault(d => d.DashId == id);
            System.Console.WriteLine ("deleting a dish...");
            System.Console.WriteLine (returnedDish);
            dbContext.dishes.Remove(returnedDish);
            dbContext.SaveChanges();
            return RedirectToAction ("Index"); 
        }

        [HttpGet("Edit/{Id}")]
        public IActionResult Edit (int id)
        {
            Dish returnedDish = dbContext.dishes.FirstOrDefault(d => d.DashId == id);
            ViewBag.ShownDish = returnedDish; 
            return View("Edit");
        }
        
        [HttpPost("Update/{Id}")]
        public IActionResult Update (int id, Dish editDish)
        {
            Dish returnedDish = dbContext.dishes.FirstOrDefault(d => d.DashId == id);
            System.Console.Write("Name: ", returnedDish.Name); 
            returnedDish.Name = editDish.Name; 
            returnedDish.Chef = editDish.Chef; 
            returnedDish.Description = editDish.Description; 
            returnedDish.Tastiness = editDish.Tastiness; 
            returnedDish.Calories = editDish.Calories; 
            returnedDish.UpdatedAt = DateTime.Now; 
            dbContext.SaveChanges(); 
            return RedirectToAction("ShowDish", returnedDish.DashId); 
        }
    }
}