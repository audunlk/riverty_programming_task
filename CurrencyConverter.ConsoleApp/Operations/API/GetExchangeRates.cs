using CurrencyConverter.ConsoleApp.Models;
using Newtonsoft.Json;

namespace CurrencyConverter.ConsoleApp.Operations.API
{
    public class GetExchangeRates
    {
        public static async Task<Response> GetExchangeRate(HttpClient client, UserInput userInput)
        {
            try
            {
                var date = userInput.Date;
                var apiKey = "4aa93365f9a2440b69fe44df555f711c";
                var apiUrl = $"http://data.fixer.io/api/{date}?access_key={apiKey}";
                //dont bothered hiding the api key, as it is limited and so you can try it out yourself.
                var response = await client.GetAsync(apiUrl);
                var content = await response.Content.ReadAsStringAsync();
                //ddeserialize the JSON response
                var result = JsonConvert.DeserializeObject<Response>(content);
                //If a client error hasnt been throw, we can assume the api returns an object.
                //return the response
                Console.WriteLine("Exchange rates successfully retrieved");
                return result;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                throw;
            }
        }
    }
}
