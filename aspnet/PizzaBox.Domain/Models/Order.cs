using System;
using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Factories;

namespace PizzaBox.Domain.Models
{
    public class Order : AEntity
    {
        private GenericPizzaFactory _pizzaFactory = new GenericPizzaFactory();

        public List<APizzaModel> Pizzas { get; set; }
        public double TotalPrice { get; set; }
        public User User { get; set; }
        public Store Store { get; set; }
        public DateTime DateModifier { get; set; }
        public Order()
        {
            Pizzas = new List<APizzaModel>();
            DateModifier = DateTime.Now;
        }
        public void MakeMeatPizza(Size size, string crust)
        {
            Pizzas.Add(_pizzaFactory.Make<MeatPizza>(size, crust));
        }
        public void MakeVeggiePizza(Size size, string crust)
        {
            Pizzas.Add(_pizzaFactory.Make<VeggiePizza>(size, crust));
        }
        public void MakeHawaianPizza(Size size, string crust)
        {
            Pizzas.Add(_pizzaFactory.Make<HawaianPizza>(size, crust));
        }
        public void MakeSupremePizza(Size size, string crust)
        {
            Pizzas.Add(_pizzaFactory.Make<SupremePizza>(size, crust));
        }
    }
}