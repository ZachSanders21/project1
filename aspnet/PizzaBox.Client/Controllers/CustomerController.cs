using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using PizzaBox.Client.Models;

namespace PizzaBox.Client.Controllers
{
    [Route("[controller]")]
    public class CustomerController : Controller
    {
        [HttpGet]
        public IEnumerable<CustomerViewModel> List()
        {
            return new List<CustomerViewModel>()
            {
                new CustomerViewModel() { Name = "Zach"}
            };
        }

    }
}