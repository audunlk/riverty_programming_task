using CurrencyConverter.ConsoleApp.Models;
using CurrencyConverter.ConsoleApp.Operations.API;


namespace CurrencyConverter.UnitTests.Systems.Operations.API
{
    public class CheckResponseValidityTests
    {
        //In a real applciation error handeling would be specified by code.
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
}
