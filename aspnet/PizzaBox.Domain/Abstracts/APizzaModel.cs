using PizzaBox.Domain.Models;
using System.Collections.Generic;

namespace PizzaBox.Domain.Abstracts
{
    public class APizzaModel : AEntity
    {
        public string Crust { get; set; }

        public Size Size { get; set; }
        public List<Topping> Toppings { get; set; }
        

        protected APizzaModel(Size size, string crust)
        {
            AddCrust(crust);
            AddSize(size);
            AddToppings();
        }
        protected APizzaModel()
        {

        }

        protected virtual void AddCrust(string crust) 
        {
            Crust = crust;
        }
        protected virtual void AddSize(Size size) 
        {
            Size = size;
        }
        protected virtual void AddToppings()
        {

        }
        protected virtual string GetPizzaName() 
        {
            return "Name";
        }
        public override string ToString()
        {
            return $"{GetPizzaName()}";
        }


    }
}