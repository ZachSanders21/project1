using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PizzaBox.Client.Models;
using PizzaBox.Domain.Models;
using PizzaBox.Storing;

namespace PizzaBox.Client.Controllers
{
    [Route("[controller]")]
    public class CustomerController : Controller
    {
        private CustomerViewModel Customer;
        private readonly PizzaBoxRepository _repo;
        public CustomerController(PizzaBoxRepository context)
        {
            _repo = context;
        }
        [HttpGet]
        public IActionResult Home()
        {
            Customer = new CustomerViewModel();

            Customer.Names = _repo.GetCustomers(); 

            return View("home", Customer);
        }
        [HttpPost("/customer")]
        public IActionResult NewUser(string username)
        {
            
            User user = new User(username);
            _repo.NewUser(user);

            return RedirectToAction("home");
        }
        [HttpPost("/select")]
        public IActionResult UserView(string username)
        {
            Customer = new CustomerViewModel();  
            _repo.user = _repo.GetUser(username);
            Customer.Name = _repo.user.Username;

            Customer.Order = new OrderViewModel()
            {
                Stores = _repo.GetStores()
            };

            Customer.Order.OrderHistory = _repo.UserOrderHistroy(_repo.user);
            

            return View("UserSelected", Customer);
        } 
        [HttpPost("/select/pizza")]
        public IActionResult SelectPizza(CustomerViewModel Customer, string storename)
        {
            _repo.store = _repo.ReadStore(storename);
            _repo.store.Name = _repo.ReadStoreName(storename);

            Customer.Name = _repo.user.Username;
            Customer.Order.Store = _repo.store.Name;
            Customer.Order.Pizzas = new List<string>()
            {
                "Meat Lovers Pizza", "Hawaiian Pizza", "Veggie Pizza", "Supreme Pizza"
            };
            

            return View("CreateOrder", Customer);
        }
        // [HttpGet("/select/store/{SelectedStore}")]
        // public IActionResult CreateOrder(CustomerViewModel Customer)
        // {
            
        //     Customer.Order = new OrderViewModel()
        //     {
        //         Pizzas = new List<string>(){"Meat Lovers Pizza", "Hawaiian Pizza", "Veggie Pizza", "Supreme Pizza"}
        //     };
        //     return View("Pizzas", Customer);
        // }
        // [HttpPost("/select/store/{SelectedStore}/{Pizza}")]
        // public IActionResult SelectPizza(CustomerViewModel Customer, string pizza)
        // {
        //     Customer.Order.PizzaSelection = pizza;


        //     return View("");
        // }
        
        
    }
}