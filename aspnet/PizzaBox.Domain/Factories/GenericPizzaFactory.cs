using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;

namespace PizzaBox.Domain.Factories
{
    class GenericPizzaFactory
    {
        public APizzaModel Make<T>(Size size, string crust) where T : class
        {
            if (typeof(T) == typeof(HawaianPizza))
            {
                return new HawaianPizza(size, crust);
            }
            if (typeof(T) == typeof(MeatPizza))
            {
                return new MeatPizza(size, crust);
            }
            if (typeof(T) == typeof(SupremePizza))
            {
                return new SupremePizza(size, crust);
            }
            if (typeof(T) == typeof(VeggiePizza))
            {
                return new VeggiePizza(size, crust);
            }
            else
            {
                return null;
            }
        }
    }
}