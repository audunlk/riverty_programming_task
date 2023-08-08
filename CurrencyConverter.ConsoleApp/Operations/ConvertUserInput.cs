using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConverter.ConsoleApp.Operations
{
    public class ConvertUserInput
    {
        public static decimal Convert(string from, string to, decimal amount, Dictionary<string, decimal> rates)
        {
            //Since with the free api base is always EUR, we need to convert the amount to EUR first
            //then convert it to the desired currency
            var baseAmount = 1;
            var fromAmount = rates[from];
            var toAmount = rates[to];
            var amountInEur = baseAmount / fromAmount * amount;
            var convertedAmount = amountInEur * toAmount;
            return convertedAmount;
            
        }
    }
}
