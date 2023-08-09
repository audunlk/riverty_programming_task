namespace CurrencyConverter.API.Models
{
    public class Rates
    {
        public int Id { get; set; }
        public string Currency { get; set; } = string.Empty;
        public decimal Value { get; set; }
        //ForeginKey to ResponseStatus
        public int ResponseStatusId { get; set; }
        
        //responsestatus ref
    }
}
