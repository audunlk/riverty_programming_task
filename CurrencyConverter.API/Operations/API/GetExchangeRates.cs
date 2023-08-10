using CurrencyConverter.API.Models;
using CurrencyConverter.ConsoleApp.Models;
using Newtonsoft.Json;

namespace CurrencyConverter.API.Operations.API;
public class GetExchangeRates
{
    public static async Task<Response> GetExchangeRate(HttpClient client, string dateString)
    {
        try
        {
            var apiKey = "4aa93365f9a2440b69fe44df555f711c";
            var apiUrl = $"http://data.fixer.io/api/{dateString}?access_key={apiKey}";
            //dont bothered hiding the api key, as it is limited and so you can try it out yourself.
            var response = await client.GetAsync(apiUrl);
            var content = await response.Content.ReadAsStringAsync();
            //deserialize the JSON response
            var result = JsonConvert.DeserializeObject<Response>(content);
            //If a client error hasnt been throw, we can assume the api returns an object.
            //return the response
            //print the response to the console
            return result;
        }
        catch (HttpRequestException ex)
        {
            throw new Exception($"{ex.Message}");
        }
        catch (Exception ex)
        {
            throw new Exception($"{ex.Message}");
        }
    }
}
