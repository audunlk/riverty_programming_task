using CurrencyConverter.ConsoleApp.Operations.Validators;
using CurrencyConverter.ConsoleApp.Models;

namespace CurrencyConverter.ConsoleApp.Operations.Input
{
    public class GetExchangeDate
    {
        public static UserInput GetDate()
        {
            Console.WriteLine("Please type a date in the format YYYY-MM-DD or press enter to use the latest rates");
            var date = Console.ReadLine();
            if (date!.Trim() == string.Empty)
            {
                date = "latest";
            }
            else if (!CheckDateValidity.CheckDate(date))
            {
                Console.WriteLine("You need to type in a valid date");
                //recursive call to get the input again
                return GetDate();
            };
            
            return new UserInput
            {
                Date = date
            };
        }
    }
}
