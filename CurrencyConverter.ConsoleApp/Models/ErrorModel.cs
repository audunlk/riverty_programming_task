
namespace CurrencyConverter.ConsoleApp.Models
{
    public class Error
    {
        public int Code { get; set; }
        public string Type { get; set; } = string.Empty;
        public string Info { get; set; } = string.Empty;
    }
}
