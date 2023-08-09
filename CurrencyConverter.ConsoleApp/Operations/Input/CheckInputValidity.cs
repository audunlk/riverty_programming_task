using CurrencyConverter.ConsoleApp.Models;

namespace CurrencyConverter.ConsoleApp.Operations.Input
{
    public class CheckInputValidity
    {
        public static bool CheckInput(Response responsemodel, string input)
        {
            if (input == string.Empty)
            {
                return false;
            }
            foreach (var rates in responsemodel.Rates)
            {
                if (input == rates.Key)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
