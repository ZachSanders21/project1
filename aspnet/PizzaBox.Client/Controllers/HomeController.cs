using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using PizzaBox.Client.Models;

namespace PizzaBox.Client.Controllers
{
    [Route("[controller]")]
    [Route("")]
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Home()
        {
            HomeViewModel home = new HomeViewModel();
            home.Controllers = new List<string>()
            {
                "Customer", "Store"
            };
            return View("index", home);
            
        }
    }
}