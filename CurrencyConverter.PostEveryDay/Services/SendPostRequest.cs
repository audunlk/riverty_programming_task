
namespace CurrencyConverter.PostEveryDay.Services
{
    public class SendPostRequest
    {
        public static async Task SendPostRequestAsync()
        {
            Console.WriteLine("Sending POST request...");
            using (var httpClient = new HttpClient())
            {
                var apiUrl = "http://localhost:5270/api/exchangerate/";
                var response = await httpClient.PostAsync(apiUrl, null);
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("POST request successful.");
                }
                else
                {
                    Console.WriteLine($"POST request failed: {response.StatusCode}");
                }
            }
        }
    }
}
