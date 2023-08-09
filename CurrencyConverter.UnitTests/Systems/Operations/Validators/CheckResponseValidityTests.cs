using CurrencyConverter.ConsoleApp.Models;
using CurrencyConverter.ConsoleApp.Operations.Validators;

namespace CurrencyConverter.UnitTests.Systems.Operations.Validators;

public class CheckResponseValidityTests
{
    //In a real applciation error handeling would be specified by code.
    //At the moment it just checks that it throws an execption in both cases.
    //This will infact also confirm that both the execption works as the condition is different for each.
    [Fact]
    //check null response failure
    public void CheckResponse_WhenResponseIsNull_ThrowsException()
    {
        //Arrange
        Response response = null;
        //Act
        //Assert
        Assert.Throws<Exception>(() => CheckResponseValidity.CheckResponse(response));
    }
    [Fact]
    //check success key failure
    public void CheckResponse_WhenResponseIsNotSuccessful_ThrowsException()
    {
        //Arrange
        var response = new Response
        {
            Success = false,
            Error = new Error
            {
                Info = "Some error message"
            }
        };
        //Act
        //Assert
        Assert.Throws<Exception>(() => CheckResponseValidity.CheckResponse(response));
    }
}
