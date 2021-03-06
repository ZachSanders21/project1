using System.Collections.Generic;

namespace PizzaBox.Client.Models
{
    public class PizzaViewModel
    {
        public string Crust { get; set; }
        public string Size { get; set; }
        public List<string> Toppings { get; set; }
        public List<string> Sizes { get; set; }
        public List<string> Crusts { get; set; }
        public decimal Price { get; set; }
    }
}