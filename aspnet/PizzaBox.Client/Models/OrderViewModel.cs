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
        public List<string> Stores { get; set; }
        public List<string> Pizzas { get; set; }

        [Required]
        public string Store { get; set; }
        [Required]
        [Range(1,50)]
        public List<string> PizzaSelection { get; set; }


        // public OrderViewModel()
        // {
        //     Stores = _ctx.Stores.Select(s => s.Name).ToList();
            
        //     Pizzas = new List<string>
        //     {
        //         "pizza1",
        //         "pizza2",
        //         "pizza3",
        //         "pizza4"
        //     };

        //     PizzaSelection = new List<string>();

        // }
    }
}