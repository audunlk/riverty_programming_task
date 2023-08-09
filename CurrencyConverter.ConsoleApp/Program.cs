using CurrencyConverter.ConsoleApp.Operations.Conversion;
using CurrencyConverter.ConsoleApp.Services;

namespace CurrencyConverter.ConsoleApp
{
    public class Program
    {
        static async Task Main()
        {
            var exchangeRates = await ExchangeServices.GetExchange();
            var userInput = GetInputFromUser.GetInput(exchangeRates);
            var convertedAmount = ConvertUserInput.Convert(userInput.FromCurrency, userInput.ToCurrency, userInput.Amount, exchangeRates.Rates);
            Console.WriteLine($"The amount {userInput.Amount} {userInput.FromCurrency} is {convertedAmount} {userInput.ToCurrency}");
            Console.WriteLine("Press any key to restart the converter");
            Console.ReadKey();
            Console.Clear();
            await Main();
        }
    }
}
