
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models
{
    public class User : AEntity
    {
        public List<Order> Orders { get; set; }
        public string Username { get; set; }

        public Store SelectedStore { get; set;}

        public User()
        {
            Orders = new List<Order>();
        }
        public User(string name)
        {
            Orders = new List<Order>();
            Username = name;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            
            foreach (var p in Orders.Last().Pizzas)
            {
                sb.AppendLine(p.ToString());
            }
            return sb.ToString();
        }
    }
}