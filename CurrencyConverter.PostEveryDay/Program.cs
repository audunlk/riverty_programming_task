//once each 24 hours
using CurrencyConverter.PostEveryDay.Services;

namespace CurrencyConverter.PostEveryDay;

public class Program
{
    static async Task Main()
    {
        while (true) 
        {
            await SendPostRequest.SendPostRequestAsync();

            //every 5 minutes to test it
            await Task.Delay(TimeSpan.FromMinutes(1));
            //for 24 hours use this
            //await Task.Delay(TimeSpan.FromHours(24));
        }
    }
}
