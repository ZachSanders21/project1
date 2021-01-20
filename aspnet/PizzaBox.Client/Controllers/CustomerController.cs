using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using PizzaBox.Client.Models;
using PizzaBox.Domain.Abstracts;
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
            User user = _repo.GetUser(username);
            Customer.Name = user.Username;
            TempData.Put<User>("User", user);

            Customer.Order = new OrderViewModel()
            {
                Stores = _repo.GetStores()
            };

            Customer.Order.OrderHistory = _repo.UserOrderHistroy(user);
            

            return View("UserSelected", Customer);
        } 
        [HttpPost("/select/pizza")]
        public IActionResult SelectPizza(CustomerViewModel Customer, string storename)
        {

            Store store = _repo.ReadStore(storename);
            store.Name = _repo.ReadStoreName(storename);
            TempData.Put<Store>("Store", store);
            User user = TempData.Get<User>("User");

            Customer.Name = user.Username;
            Customer.Order.Store = store.Name;
            Customer.Order.Pizzas = new List<string>()
            {
                "Meat Lovers Pizza", "Hawaiian Pizza", "Veggie Pizza", "Supreme Pizza"
            };
            Customer.Order.Pizza.Sizes = new List<string>()
            {
                "Small", "Medium", "Large"
            };
            Customer.Order.Pizza.Crusts = new List<string>()
            {
                "Garlic", "Seasame", "Butter", "Plain"
            };
            user.SelectedStore = store;
            // user.SelectedStore.CreateOrder();
            Order order = new Order();
            user.Orders.Add(order);

            TempData.Put<User>("User", user);
            TempData.Put<CustomerViewModel>("Customer", Customer);
            return View("CreateOrder", Customer);
        }
        [HttpPost("/select/pizza/order")]
        public IActionResult CreateOrder(CustomerViewModel Customer, string crust, string sizename, string pizzatype)
        {
            Customer = TempData.Get<CustomerViewModel>("Customer");
            User user = TempData.Get<User>("User");
            Store store = TempData.Get<Store>("Store");

            Size size = default;
            switch (sizename)
            {
                case "Small":
                    size = new Size("Small");
                    break;
                case "Medium":
                    size = new Size("Medium");
                    break;
                case "Large":
                    size = new Size("Large");
                    break;

            }
            switch (pizzatype)
            {
                case "Hawaiian Pizza":
                    user.Orders.Last().MakeHawaianPizza(size, crust);
                    break;
                case "Meat Lovers Pizza":
                    user.Orders.Last().MakeMeatPizza(size, crust);
                    break;
                case "Supreme Pizza":
                    user.Orders.Last().MakeSupremePizza(size, crust);
                    break;
                case "Veggie Pizza":
                    user.Orders.Last().MakeVeggiePizza(size, crust);
                    break;
            }
            Customer.Order.CurrentOrder = user.Orders.Last();

            double totalprice = 0;
            foreach (APizzaModel pizza in user.Orders.Last().Pizzas)
            {
                totalprice += pizza.Size.Price;
                foreach (Topping topping in pizza.Toppings)
                {
                    totalprice += topping.Price;
                }
            }
            user.Orders.Last().TotalPrice = totalprice;
            user.Orders.Last().Store = user.SelectedStore;
            TempData.Put<User>("User", user);
            TempData.Put<CustomerViewModel>("Customer", Customer);
            
            return View("Pizzas", Customer);
        }
        [HttpPost("/select/pizza/order/finish")]
        public IActionResult Checkout(CustomerViewModel Customer)
        {
            User user = TempData.Get<User>("User");
            
            User dbuser = _repo.GetUser(user.Username);
            dbuser.Orders = user.Orders;
            _repo.Update();
            return View("OrderPass");
        }
        
        
    }
}