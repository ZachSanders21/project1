using System.Collections.Generic;
using Microsoft.Extensions.Configuration;

namespace PizzaBox.Client.Models
{
    public class CustomerViewModel
    {
        public List<string> Names { get; set; }
        public string Name { get; set; }
        public OrderViewModel Order { get; set; }
        public string SelectedStore { get; set; }

        public CustomerViewModel()
        {
            Order = new OrderViewModel();
        }
        
    }
}