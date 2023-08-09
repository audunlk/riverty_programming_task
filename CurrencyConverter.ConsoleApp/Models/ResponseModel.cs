
namespace CurrencyConverter.ConsoleApp.Models
{
    public class Response
    {
        public bool Success { get; set; }
        public Error Error { get; set; } = new Error();
        public long Timestamp { get; set; }
        public string Base { get; set; } = "EUR";
        public DateTime Date { get; set; }
        public Dictionary<string, decimal> Rates { get; set; } = new Dictionary<string, decimal>();
    }

    public class Error
    {
        public int Code { get; set; }
        public string Type { get; set; } = string.Empty;
        public string Info { get; set; } = string.Empty;
    }
}
