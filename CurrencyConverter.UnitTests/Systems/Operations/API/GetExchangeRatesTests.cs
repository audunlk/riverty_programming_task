using CurrencyConverter.ConsoleApp.Models;
using CurrencyConverter.ConsoleApp.Operations.API;
using CurrencyConverter.ConsoleApp.Services;
using CurrencyConverter.ConsoleApp.Utilities;
using CurrencyConverter.ConsoleApp.Operations.Input;
using Moq;
using Moq.Protected;

namespace CurrencyConverter.UnitTests.Systems.Operations.API
{
    public class GetExchangeRatesTests
    {

        [Fact]
        public async void GetExchangeRates_Returns_Correct_Model()
        {
            //Arrange
            var httpClient = new HttpClientFactory().CreateHttpClient();
            var dateString = "2021-01-01";
            //Act
            var result = await GetExchangeRates.GetExchangeRate(httpClient, dateString);
            //Assert
            Assert.IsType<Response>(result);
        }
        [Fact]
        public async Task GetExchangeRate_Throws_HttpRequestException_On_Client_Error()
        {
            //Arrange
            //create a mock client and crash it
            var mockHttpMessageHandler = new Mock<HttpMessageHandler>();
            mockHttpMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                .ThrowsAsync(new HttpRequestException());
            var httpClient = new HttpClient(mockHttpMessageHandler.Object);
            var dateString = "2021-01-01";

            //Assert
            await Assert.ThrowsAsync<HttpRequestException>(() => GetExchangeRates.GetExchangeRate(httpClient, dateString));
        }
    }
}
