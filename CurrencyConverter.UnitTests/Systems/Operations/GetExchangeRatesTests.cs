using CurrencyConverter.ConsoleApp.Models;
using CurrencyConverter.ConsoleApp.Operations;

namespace CurrencyConverter.UnitTests.Systems.Operations
{
    public class GetExchangeRatesTests
    {
        //Checking if the api returns a response model is enough to check if the api is working
        //If it were to return something else than a valid model, the test would fail
        //For a real application I would have included more tests to specify the error messages
        //For this example either its returning a successful response or it is not.
        [Fact]
    public async void GetExchangeRates_Returns_Correct_Model()
    {
        //Act
        var result = await GetExhangeRates.GetExchangeRate();
        //Assert
        Assert.IsType<Response>(result);
    }
    }
}
