using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models
{
    public class Size : AEntity
    {
        public string Name { get; set; }
        public List<APizzaModel> Pizzas { get; set; }
        public double Price { get; set; }
        public Size()
        {

        }
        public Size(string name)
        {
            Name = name;
            if (name == "Small")
            {
                Price = 0;
            }
            else if (name == "Medium")
            {
                Price = 2;
            }
            else if (name == "Large")
            {
                Price = 4;
            }
        }

        public override string ToString()
        {
            return $"{Name}";
        }
    }
}