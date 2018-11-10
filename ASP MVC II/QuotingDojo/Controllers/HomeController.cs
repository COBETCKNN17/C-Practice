using System;
using System.Linq;
using DbConnection;
using Microsoft.AspNetCore.Mvc;

namespace QuotingDojo {
    public class HomeController : Controller {
        [HttpGet]
        [Route ("")]
        public IActionResult Index () {
            if (TempData["Error"] != null) {
                ViewBag.Error = TempData["Error"];
            }
            return View ();
        }

        [HttpPost ("/quotes")]
        public IActionResult Create (string name, string quote) {
            if (name == "" || quote == "") {
                TempData["Error"] = "Fields cannot be empty.";
            }
            string query = $"INSERT INTO quotes (quote, name, created_at, updated_at) VALUES ('{quote}', '{name}', NOW(), NOW());";
            DbConnector.Execute (query);
            return RedirectToAction ("Quotes");
        }

        [HttpGet ("/quotes")]
        public IActionResult Quotes () {
            //Get all quotes
            string query = "SELECT * FROM quotes";
            var quotes = DbConnector.Query (query);

            //Sort them by created time descending
            quotes = quotes.OrderByDescending ((quote) => quote["created_at"]).ToList ();

            //Format all of the dates
            foreach (var quote in quotes) {
                DateTime created = (DateTime) quote["created_at"];
                string formatted_created = String.Format ("{0:h:mm tt MMMM d yyyy}", created);
                quote["created_at"] = formatted_created;
            }

            ViewBag.Quotes = quotes;
            return View ();
        }
    }
}