using CurrencyConverter.ConsoleApp.Utilities;
using CurrencyConverter.ConsoleApp.Models;
using CurrencyConverter.API.Operations.API;

namespace CurrencyConverter.API.Services
{
    public class ExchangeServices
        {
            public static async Task<Response> GetExchange(string dateString)
            {
                try
                {
                    var client = new HttpClientFactory().CreateHttpClient();
                    var exchangeRates = await GetExchangeRates.GetExchangeRate(client, dateString);
                    //CheckResponseValidity.CheckResponse(exchangeRates);
                    return exchangeRates;
                }
                catch (Exception ex)
                {
                    throw new Exception($"An error occurred: {ex.Message}");
                }
            }
        }
    }
