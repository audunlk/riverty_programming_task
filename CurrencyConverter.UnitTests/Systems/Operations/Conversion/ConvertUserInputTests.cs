using CurrencyConverter.ConsoleApp.Models;
using CurrencyConverter.ConsoleApp.Operations.Conversion;

namespace CurrencyConverter.UnitTests.Systems.Operations.Conversion
{
    public class ConvertUserInputTests
    {
        //We already check if the from and to currency is in the dictionary
        //We can therefore assume that the from and to currency is in the dictionary
        //We also assume that the amount is a valid number
        //We can therefore only check the calculation
        [Fact]
        public void ConvertUserInput_Returns_Correct_Value()
        {
            //Arrange
            var from = "USD";
            var to = "EUR";
            var amount = 8m;
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
            var result = ConvertUserInput.Convert(from, to, amount, responseModel.Rates);
            //Assert
            Assert.Equal(6.6667m, result);

        }

    }
}
