using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;

namespace PizzaBox.Client.Models
{
    public class StoreViewModel
    {
        public OrderViewModel Order { get; set; }
        public string Name { get; set; }
        
        // public StoreViewModel()
        // {
        //     Stores = new List<Store>();
        // }
        
    }
    
}