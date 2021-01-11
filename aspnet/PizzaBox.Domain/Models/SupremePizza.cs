using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models
{
    public class SupremePizza : APizzaModel
    {
        public SupremePizza(Size size, string crust) : base(size, crust)
        {
            
        }
        protected override void AddToppings()
        {
            Toppings = new List<Topping>();
            Toppings.Add(new Topping("Sausage"));
            Toppings.Add(new Topping("Cheese"));
            Toppings.Add(new Topping("Bacon"));
            Toppings.Add(new Topping("Chicken"));
            Toppings.Add(new Topping("Anchovy"));
        }
        protected override string GetPizzaName()
        {
            return "Supreme Pizza";
        }
    }
}