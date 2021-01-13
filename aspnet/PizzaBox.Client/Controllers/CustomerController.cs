using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PizzaBox.Client.Models;
using PizzaBox.Storing;

namespace PizzaBox.Client.Controllers
{
    [Route("[controller]")]
    public class CustomerController : Controller
    {
        private readonly PizzaBoxRepository _ctx;
        public CustomerController(PizzaBoxRepository context)
        {
            _ctx = context;
        }
        [HttpGet]
        public IActionResult Home()
        {
            var customer = new CustomerViewModel();

            customer.Order = new OrderViewModel()
            {
                Stores = _ctx.GetStores()
            };

            return View("home", customer);
        }
        
    }
}