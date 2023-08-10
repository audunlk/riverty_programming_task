using CurrencyConverter.ConsoleApp.Models;
using CurrencyConverter.API.Models;

namespace CurrencyConverter.API.Operations.Deserialization
{
    public class CreateErrorObject
    {
        public static ErrorTable CreateObject(Response response, int id)
        {
            var error = new ErrorTable
            {
                Code = response.Error.Code,
                Type = response.Error.Type,
                Info = response.Error.Info,
                ResponseStatusId = id
            };
            return error;
        }
    }
}
