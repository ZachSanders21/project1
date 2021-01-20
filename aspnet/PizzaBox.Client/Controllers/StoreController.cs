using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using PizzaBox.Client.Models;
using PizzaBox.Domain.Models;
using PizzaBox.Storing;

namespace PizzaBox.Client.Controllers
{
    [Route("[controller]")]
    public class StoreController : Controller
    {
        private StoreViewModel storeview;
        private readonly PizzaBoxRepository _repo;
        public StoreController(PizzaBoxRepository context)
        {
            _repo = context;
        }
        [HttpGet]
        public IActionResult Home()
        {
            storeview = new StoreViewModel();
            storeview.Names = _repo.GetStores();
            storeview.Options = new List<string>()
            {
                "Sales History", "Order History"
            };
            storeview.Order = new OrderViewModel();
            TempData.Put<StoreViewModel>("storeview", storeview);
            return View("StoreView", storeview);
        }
        [HttpPost("/choice")]
        public IActionResult StoreChoice(StoreViewModel storeview, string storename, string option)
        {
            storeview = TempData.Get<StoreViewModel>("storeview");
            Store store = _repo.ReadStore(storename);
            storeview.Name = storename;
            switch (option)
            {
                case "Sales History":
                    TempData.Put<Store>("Store", store);
                    storeview.TimeSet = new List<string>()
                    {
                        "Weekly", "Monthly"
                    };
                    TempData.Put<StoreViewModel>("storeview", storeview);
                    return View("TimeView", storeview);
                case "Order History":
                    storeview.Order.OrderHistory = _repo.StoreOrderHistory(store);
                    break;
            }
            TempData.Keep();
            return View("Order", storeview);
        }
        [HttpPost("/choice/sales")]
        public IActionResult TimeSelect(StoreViewModel storeview, string timeselect)
        {
            storeview = TempData.Get<StoreViewModel>("storeview");
            Store store = TempData.Get<Store>("store");
            switch (timeselect)
            {
                case "Weekly":
                    IEnumerable<Order> orderhist = _repo.StoreOrderHistory(store);
                        double totalprice = 0;
                        double totalorder = 0;
                        foreach (Order order in orderhist)
                        {
                            if (order.DateModifier > DateTime.Now.AddDays(-7))
                            {
                                totalprice += order.TotalPrice; 
                                totalorder += 1;
                            }
                        }
                    storeview.TotalPrice = totalprice;
                    storeview.TotalOrders = totalorder;
                    break;
                case "Monthly":
                    IEnumerable<Order> orderhistmonth = _repo.StoreOrderHistory(store);
                        double totalpricemonth = 0;
                        double totalordermonth = 0;
                        foreach (Order order in orderhistmonth)
                        {
                            if (order.DateModifier > DateTime.Now.AddDays(-7))
                            {
                                totalpricemonth += order.TotalPrice; 
                                totalordermonth += 1;
                            }
                        }
                    storeview.TotalPrice = totalpricemonth;
                    storeview.TotalOrders = totalordermonth;
                    break;
            }
            TempData.Keep();
            return View("SalesView", storeview);
        }
    }
}