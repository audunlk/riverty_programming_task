using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using CurrencyConverter.ConsoleApp.Operations;

namespace CurrencyConverter.ConsoleApp
{
    internal class Program
    {
        static async Task Main()
        {
            //get the latest exchange rates from the api
            var exchangeRates = await GetExhangeRates.GetExchangeRate();
            //include exhange rates in the user input so we can check if input is valid
            var userInput = GetInputFromUser.GetInput(exchangeRates);
            //convert the amount, using the input and the object collected with the api call
            var convertedAmount = ConvertUserInput.Convert(userInput.FromCurrency, userInput.ToCurrency, userInput.Amount, exchangeRates.Rates);
            Console.WriteLine($"The amount {userInput.Amount} {userInput.FromCurrency} is {convertedAmount} {userInput.ToCurrency}");
            //restart the converter
            Console.WriteLine("Press any key to restart the converter");
            Console.ReadKey();
            Console.Clear();
            await Main();

        }
    }
}
