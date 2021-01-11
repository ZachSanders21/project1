using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models
{
    public class HawaianPizza : APizzaModel
    {
        public HawaianPizza(Size size, string crust) : base(size, crust)
        {
            
        }

        protected override void AddToppings()
        {
            Toppings = new List<Topping>();
            Toppings.Add(new Topping("Pineapple"));
            Toppings.Add(new Topping("Ham"));
            Toppings.Add(new Topping("Onion"));
        }
        protected override string GetPizzaName()
        {
            return "Hawaian Pizza";
        }
    }
}