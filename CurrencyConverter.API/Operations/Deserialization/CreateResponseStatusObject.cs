using CurrencyConverter.API.Models;
using CurrencyConverter.ConsoleApp.Models;

namespace CurrencyConverter.API.Operations.Deserialization
{
    public class CreateResponseStatusObject
    {
        public static ResponseStatusTable CreateObject(Response response)
        {
            var responseStatus = new ResponseStatusTable
            {
                Success = response.Success,
                Timestamp = response.Timestamp,
                Base = response.Base,
                Date = response.Date
            };
            return responseStatus;
        }
    }
}
