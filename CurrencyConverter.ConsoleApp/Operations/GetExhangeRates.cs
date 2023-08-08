using CurrencyConverter.ConsoleApp.Models;
using Newtonsoft.Json;

namespace CurrencyConverter.ConsoleApp.Operations
{
    public class GetExhangeRates
    {
        public static async Task<Response> GetExchangeRate()
        {
            try
            {
                var apiUrl = "http://data.fixer.io/api/latest?access_key=";
                //dont bothered hiding the api key, as it is limited and so you can try it out yourself.
                var apiKey = "4aa93365f9a2440b69fe44df555f711c";
                var client = new HttpClient();
                var response = await client.GetAsync(apiUrl + apiKey);
                var content = await response.Content.ReadAsStringAsync();

                //ddeserialize the JSON response
                var result = JsonConvert.DeserializeObject<Response>(content);
                //check if the API response is valid
                //would give more specific error messages if this was a real application
                if (result == null || !result.Success)
                {
                    throw new Exception("The API response is not valid :(");
                }
                //return the response
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                throw;
            }
        }
    }
}
