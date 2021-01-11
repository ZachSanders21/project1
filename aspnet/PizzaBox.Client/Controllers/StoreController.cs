using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using PizzaBox.Client.Models;

namespace PizzaBox.Client.Controllers
{
    [Route("[controller]")]
    public class StoreController : Controller
    {
        [HttpGet]
        public IActionResult Get()
        {
            var stores = new StoreViewModel(); // static type inference

            // 1-way data binding
            ViewBag.Stores = stores.temps; // dynamic object
            // ViewData["Stores"] = stores; //dictionary object, dictionary<string, object>

            // response data binding
            // TempData["Stores"] = stores;

            return View("StrongStore", new StoreViewModel());
        }
        [HttpGet("{store}")] //http://Localhost:5000/store/<some value>
        public IActionResult Get(string store)
        {
            return View("Store", store);
        }

    }
}