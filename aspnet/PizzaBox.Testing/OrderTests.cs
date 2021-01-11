using System.Linq;
using PizzaBox.Domain.Models;
using Xunit;

namespace PizzaBox.Testing
{
    public class OrderTests
    {
        [Fact]
        private void Test_OrderExists()
        {
            // arrange
            var sut = new Order(); // inference
            // Order sut1 = new Order(); // memory allocation

            // act
            var actual = sut;

            // assert
            Assert.IsType<Order>(actual);
            Assert.NotNull(actual);
        }
        [Fact]
        private void Test_MakeMeatPizza()
        {
            Order test = new Order();
            Size size = new Size("Huge");
            string crust = "pizza";
            test.MakeMeatPizza(size, crust);

            Assert.Equal(size, test.Pizzas.First().Size);
            Assert.Equal(crust, test.Pizzas.First().Crust);
        }
        [Fact]
        private void Test_MakeVeggiePizza()
        {
            Order test = new Order();
            Size size = new Size("Huge");
            string crust = "pizza";
            test.MakeVeggiePizza(size, crust);

            Assert.Equal(size, test.Pizzas.First().Size);
            Assert.Equal(crust, test.Pizzas.First().Crust);
        }
        [Fact]
        private void Test_MakeHawaianPizza()
        {
            Order test = new Order();
            Size size = new Size("Huge");
            string crust = "pizza";
            test.MakeHawaianPizza(size, crust);

            Assert.Equal(size, test.Pizzas.First().Size);
            Assert.Equal(crust, test.Pizzas.First().Crust);
        }
        [Fact]
        private void Test_MakeSupremePizza()
        {
            Order test = new Order();
            Size size = new Size("Huge");
            string crust = "pizza";
            test.MakeSupremePizza(size, crust);

            Assert.Equal(size, test.Pizzas.First().Size);
            Assert.Equal(crust, test.Pizzas.First().Crust);
        }
    }
}