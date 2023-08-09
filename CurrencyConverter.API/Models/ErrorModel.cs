namespace CurrencyConverter.API.Models
{
    public class Error
    {
        public int Id { get; set; }
        public int Code { get; set; }
        public string Type { get; set; } = string.Empty;
        public string Info { get; set; } = string.Empty;
        //ForeginKey to ResponseStatus
        public int ResponseStatusId { get; set; }
        public ResponseStatus ResponseStatus { get; set; } = null!;

    }
}
