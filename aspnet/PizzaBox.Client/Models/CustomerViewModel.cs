using System.Collections.Generic;
using Microsoft.Extensions.Configuration;

namespace PizzaBox.Client.Models
{
    public class CustomerViewModel
    {
        public string Name { get; set; }
        public OrderViewModel Order { get; set; }

        public CustomerViewModel()
        {
            Name = "Zach";
            Order = new OrderViewModel();
        }
        
    }
}