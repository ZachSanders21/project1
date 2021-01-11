using PizzaBox.Domain.Models;
using Xunit;

namespace PizzaBox.Testing
{
    public class MeatPizzaTests
    {
        [Fact]
        private void Test_MeatPizzaExists()
        {
            // arrange
            Size size = new Size("Small");
            string crust = "Garlic";
            MeatPizza meatpizza = new MeatPizza(size, crust);

            Assert.Equal(size, meatpizza.Size); 
            Assert.Equal(crust, meatpizza.Crust);
        }  
    }
    
}