using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PizzaBox.Client.Models;
using PizzaBox.Domain.Models;
using PizzaBox.Storing;

namespace PizzaBox.Client.Controllers
{
    [Route("[controller]")]
    public class OrderController : Controller
    {
        private PizzaBoxContext _ctx;
        public OrderController(PizzaBoxContext context)
        {
            _ctx = context;
        }
        [HttpGet]
        public ViewResult Get()
        {
            return View("Order");
        }
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            return View("Order", new OrderViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Post(OrderViewModel model)
        {
            if (ModelState.IsValid)
            {
                var order = new Order()
                {
                DateModifier = DateTime.Now,
                Store = _ctx.Stores.FirstOrDefault(s => s.Name == model.Store)
                };
                _ctx.Orders.Add(order);
                _ctx.SaveChanges();
                return View("OrderPass");
            }
            return View("home", model);
        }


    }
}