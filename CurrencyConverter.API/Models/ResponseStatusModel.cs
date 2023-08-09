namespace CurrencyConverter.API.Models
{
    public class ResponseStatus
    {
        public int Id { get; set; }
        public bool Success { get; set; }
        public long Timestamp { get; set; }
        public string Base { get; set; } = "EUR";
        public DateTime Date { get; set; }
        //icollection rates
        public ICollection<Rates> Rates { get; set; } = null!;
        public ICollection<Error> Errors { get; set; } = null!;
    }
}
