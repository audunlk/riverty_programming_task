using CurrencyConverter.ConsoleApp.Models;
using CurrencyConverter.ConsoleApp.Operations.Validators;

public class GetInputFromUser
{
    //would split further into different classes if real application.
    public static UserInput GetInput(Response responsemodel)
    {
        var from = GetCurrencyFromUser("Please type in the currency code you want to convert from. EXAMPLE: USD", responsemodel);
        var to = GetCurrencyFromUser("Please type in the currency code you want to convert to", responsemodel);
        var amount = GetAmountFromUser();

        return new UserInput
        {
            FromCurrency = from,
            ToCurrency = to,
            Amount = amount
        };
    }

    private static string GetCurrencyFromUser(string message, Response responsemodel)
    {
        Console.WriteLine(message);
        var currencyCode = Console.ReadLine().ToUpper();

        if (CheckInputValidity.CheckInput(responsemodel, currencyCode) == false)
        {
            Console.WriteLine("You need to type in a valid currency code");
            return GetCurrencyFromUser(message, responsemodel); // Recursive call
        }

        return currencyCode;
    }

    private static decimal GetAmountFromUser()
    {
        Console.WriteLine("Please type in the amount you want to convert");
        var amountString = Console.ReadLine();

        if (decimal.TryParse(amountString, out decimal amount) == false)
        {
            Console.WriteLine("You need to type in a valid amount");
            return GetAmountFromUser(); // Recursive call
        }

        return amount;
    }
}