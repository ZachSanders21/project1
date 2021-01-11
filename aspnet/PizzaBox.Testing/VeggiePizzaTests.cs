using PizzaBox.Domain.Models;
using Xunit;

namespace PizzaBox.Testing
{
    public class VeggiePizzaTests
    {
        [Fact]
        private void Test_VeggiePizzaExists()
        {
            // arrange
            Size size = new Size("Small");
            string crust = "Garlic";
            VeggiePizza veggiepizza = new VeggiePizza(size, crust);

            Assert.Equal(size, veggiepizza.Size); 
            Assert.Equal(crust, veggiepizza.Crust);
        }  
    }
    
}