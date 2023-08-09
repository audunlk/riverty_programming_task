using CurrencyConverter.ConsoleApp.Models;
using CurrencyConverter.ConsoleApp.Operations.API;
using CurrencyConverter.ConsoleApp.Utilities;
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
            //Act
            var result = await GetExchangeRates.GetExchangeRate(httpClient);
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

            //Assert
            await Assert.ThrowsAsync<HttpRequestException>(() => GetExchangeRates.GetExchangeRate(httpClient));
        }
    }
}
