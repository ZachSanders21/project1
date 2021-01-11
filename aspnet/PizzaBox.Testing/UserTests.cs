using PizzaBox.Domain.Models;
using Xunit;

namespace PizzaBox.Testing
{
    public class UserTests
    {
        [Fact]
        private void Test_UserExists()
        {
            // arrange
            var sut = new User(); // inference
            // Order sut1 = new Order(); // memory allocation

            // act
            var actual = sut;

            // assert
            Assert.IsType<User>(actual);
            Assert.NotNull(actual);
        }
        [Fact]
        private void Test_UserNameExists()
        {
            // arrange
            string name = "Zach";
            User user = new User(name);

            Assert.Equal(name, user.Username);
            Assert.Empty(user.Orders);

        }
        
    }
}