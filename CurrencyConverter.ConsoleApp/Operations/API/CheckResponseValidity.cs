using CurrencyConverter.ConsoleApp.Models;

namespace CurrencyConverter.ConsoleApp.Operations.API
{
    public class CheckResponseValidity
    {
        public static void CheckResponse(Response response)
        {
            if (response == null)
            {
                throw new Exception("Something went wrong, please try again later.");
            }
            if (!response.Success)
            {
                throw new Exception(response.Error.Info);
            }
        }
    }
}
