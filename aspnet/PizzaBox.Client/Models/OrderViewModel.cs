using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PizzaBox.Client.Models
{
    public class OrderViewModel
    {
        public List<string> Stores { get; set; }
        public List<string> Pizzas { get; set; }

        [Required]
        public string Store { get; set; }
        [Required]
        [Range(1,50)]
        public List<string> PizzaSelection { get; set; }

        public OrderViewModel()
        { 
            Pizzas = new List<string>
            {
                "pizza1",
                "pizza2",
                "pizza3",
                "pizza4"
            };
            Stores = new List<string>
            {
                "one",
                "two",
                "three",
                "four"
            };
           

            PizzaSelection = new List<string>();

        }
    }
}