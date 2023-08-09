using CurrencyConverter.ConsoleApp.Models;
using CurrencyConverter.ConsoleApp.Operations.Validators;

namespace CurrencyConverter.UnitTests.Systems.Operations.Validators;
public class CheckInputValidityTests
{
    [Fact]
    public void CheckInputValidity_Returns_True_If_Input_Is_Valid()
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
        var input = "USD";
        //Act
        var result = CheckInputValidity.CheckInput(responseModel, input);
        //Assert
        Assert.True(result);
    }
    [Fact]
    public void CheckInputValidity_Returns_False_If_Input_Is_Invalid()
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
        var input = "12340";
        //Act
        var result = CheckInputValidity.CheckInput(responseModel, input);
        //Assert
        Assert.False(result);
    }


}