using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Microsoft.Extensions.Configuration;
using PizzaBox.Domain.Models;
using PizzaBox.Storing;

namespace PizzaBox.Client.Models
{
    public class OrderViewModel
    {
        public List<string> Names { get; set; }
        public List<string> Stores { get; set; }
        public List<string> Pizzas { get; set; }

        [Required]
        public string Store { get; set; }
        [Required]
        [Range(1,50)]
        public string PizzaSelection { get; set; }
        public IEnumerable<Order> OrderHistory { get; set; }


        public OrderViewModel()
        {
            Stores = new List<string>
            {
                "first",
                "second",
                "third"
            };
            
            Pizzas = new List<string>
            {
                "pizza1",
                "pizza2",
                "pizza3",
                "pizza4"
            };


        }
    }
}