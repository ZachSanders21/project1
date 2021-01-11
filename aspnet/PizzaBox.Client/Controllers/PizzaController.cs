using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using PizzaBox.Client.Models;

namespace PizzaBox.Client.Controllers
{
    [Route("[controller]")]
    public class PizzaController : Controller
    {
        [HttpGet]
        public IEnumerable<PizzaViewModel> List()
        {
            return new List<PizzaViewModel>()
            {
                new PizzaViewModel() { Crust = "regular", Size = "medium", Price = 10 }
            };
        }

    }
}