using CurrencyConverter.ConsoleApp.Models;
using CurrencyConverter.ConsoleApp.Operations;

namespace CurrencyConverter.UnitTests.Systems.Operations
{
    public class GetInputFromUserTests
    {
        [Fact]
        public void GetInputFromUser_Returns_Correct_Model()
        {
            //Arrange
            var responseModel = new Response
            {
                Rates = new Dictionary<string, decimal>
                {
                    { "USD", 1.2m },
                    { "GBP", 0.8m },
                    { "EUR", 1m }
                }
            };

            //Act
            var result = GetInputFromUser.GetInput(responseModel);
            //Assert
            Assert.IsType<UserInput>(result);
        }
    }
}
