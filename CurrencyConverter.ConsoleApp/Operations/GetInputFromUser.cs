using CurrencyConverter.ConsoleApp.Models;

namespace CurrencyConverter.ConsoleApp.Operations
{
    public class GetInputFromUser
    {
        //let the user type a currency code from and to pluss an amount
        public static UserInput GetInput(Response responsemodel)
        {
            //Get the from currency from the user
            Console.WriteLine("Please type in the currency code you want to convert from. EXAMPLE: USD");
            var from = Console.ReadLine();
            //check if the currency code is valid
            if(CheckInputValidity.CheckInput(responsemodel, from!) == false)
            {
                Console.WriteLine("You need to type in a valid currency code");
                //recursive call to get the input again
                return GetInput(responsemodel);
            }

            //Get the to currency from the user
            Console.WriteLine("Please type in the currency code you want to convert to");
            var to = Console.ReadLine();
            if(CheckInputValidity.CheckInput(responsemodel, to!) == false)
            {
                Console.WriteLine("You need to type in a valid currency code");
                //recursive call to get the input again
                return GetInput(responsemodel);
            }
            //Get the amount from the user
            Console.WriteLine("Please type in the amount you want to convert");
            var amountString = Console.ReadLine();
            //convert the amount to decimal

            //check for right input type
            if(decimal.TryParse(amountString, out decimal amount) == false)
            {
                Console.WriteLine("You need to type in a valid amount");
                //recursive call to get the input again
                return GetInput(responsemodel);
            }

            //return as object with from to and amount
            return new UserInput
            {
                FromCurrency = from!.ToUpper(),
                ToCurrency = to!.ToUpper(),
                Amount = amount
            };
        }
    }
}
