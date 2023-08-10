using CurrencyConverter.API.Models;

namespace CurrencyConverter.API.Operations.Deserialization
{
    public class CreateRateObjects
    {
        public static RatesTable CreateObject(KeyValuePair<string, decimal> kvp, int id)
        {
            var rates = new RatesTable
            {
                Currency = kvp.Key,
                Value = kvp.Value,
                ResponseStatusId = id
            };
            return rates;
        }

    }
}
