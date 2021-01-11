using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models
{
    public class Topping : AEntity
    {
        public string Name { get; set; }
        public List<APizzaModel> Pizzas { get; set; }
        public double Price { get; set; }
        public Topping()
        {

        }
        public Topping(string name)
        {
            Name = name;
            if (name == "Cheese")
            {
                Price = 3;
            }
            else if (name == "Pepperoni")
            {
                Price = 2;
            }
            else if (name == "Pineapple")
            {
                Price = 1;
            }
            else if (name == "Sausage")
            {
                Price  = 2;
            }
            else if (name == "Ham")
            {
                Price = 1;
            }
            else if (name == "Onion")
            {
                Price = 1;
            }
            else if (name == "Bacon")
            {
                Price = 3;
            }
            else if (name == "Chicken")
            {
                Price = 3;
            }
            else if (name == "Anchovy")
            {
                Price = 2;
            }
            else if (name == "Cucumber")
            {
                Price = 1;
            }
            else if (name == "Mushroom")
            {
                Price = 1;
            }
            else if (name == "Spinach")
            {
                Price = 1;
            }
        }

        public override string ToString()
        {
            return $"{Name}";
        }
 
    }
}