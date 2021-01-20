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
        public List<string> Names { get; set; }
        public List<string> Options { get; set; }
        public List<string> TimeSet { get; set; }
        public double TotalPrice { get; set; }
        public double TotalOrders { get; set; }
        
        public StoreViewModel()
        {

        }
        
    }
    
}