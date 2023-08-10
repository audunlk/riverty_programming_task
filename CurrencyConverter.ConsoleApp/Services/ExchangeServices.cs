using CurrencyConverter.ConsoleApp.Models;
using CurrencyConverter.ConsoleApp.Operations.API;
using CurrencyConverter.ConsoleApp.Operations.Input;
using CurrencyConverter.ConsoleApp.Operations.Validators;
using CurrencyConverter.ConsoleApp.Utilities;

namespace CurrencyConverter.ConsoleApp.Services
{
    public class ExchangeServices
    {
        public static async Task<Response> GetExchange(string dateString)
        {
            try
            {
                //changing this to accept the user input outside the function, so it can be used in the API
                var client = new HttpClientFactory().CreateHttpClient();
                var exchangeRates = await GetExchangeRates.GetExchangeRate(client, dateString);
                CheckResponseValidity.CheckResponse(exchangeRates);
                return exchangeRates;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                throw;
            }
        }
    }
}
