using System.Collections.Generic;
using System.Linq;
using PizzaBox.Domain.Models;
using Xunit;

namespace PizzaBox.Testing
{
    public class StoreTests
    {
        [Fact]
        private void Test_StoreExists()
        {
            // arrange
            var sut = new Store(); // inference
            // Order sut1 = new Order(); // memory allocation

            // act
            var actual = sut;

            // assert
            Assert.IsType<Store>(actual);
            Assert.NotNull(actual);
        }
        [Fact]
        private void Test_CreateOrder()
        {
            Store store = new Store();
            List<Order> orders = new List<Order>();
            store.CreateOrder();

            Assert.NotEmpty(store.Orders);
            Assert.NotNull(store.Orders.First());
        }
        [Fact]
        private void Test_DeleteOrder()
        {
            Store store = new Store();
            List<Order> orders = new List<Order>();
            store.CreateOrder();
            bool isdeleted = store.DeleteOrder(store.Orders.First());

            Assert.Empty(store.Orders);
            Assert.True(isdeleted);
        }
    }   
}