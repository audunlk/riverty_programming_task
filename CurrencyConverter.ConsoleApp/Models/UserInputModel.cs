
namespace CurrencyConverter.ConsoleApp.Models
{
    public class UserInput
    {
        public string FromCurrency { get; set; } = string.Empty;
        public string ToCurrency { get; set; } = string.Empty;
        public string Date { get; set; } = string.Empty;
        public decimal Amount { get; set; }
    }
}
