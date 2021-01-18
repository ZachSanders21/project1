using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models
{
    public class Store : AEntity 
    {
        public string Name { get; set; }
        public List<Order> Orders { get; set; }
     

        public Store()
        {
            Orders = new List<Order>();
        }
        public Store(string name)
        {
            Orders = new List<Order>();
            Name = name;
        }

        public void CreateOrder()
        {
            Orders.Add(new Order());
        }
        public bool DeleteOrder(Order order)
        {
            try
            {
            Orders.Remove(order);

            return true;
            }
            catch
            {
                return false;
            }
        }
        public override string ToString()
        {
            return $"{Name}";
        }



    }
}