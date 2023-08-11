using System.ComponentModel.DataAnnotations.Schema;

namespace CurrencyConverter.API.Models
{
    public class ResponseStatusTable
    {
        
        public int Id { get; set; }
        //Success could also be error code 200 meaning success
        //other codes meaning error
        //could include error info and type as nullable
        public bool Success { get; set; }
        public long Timestamp { get; set; }
        public string Base { get; set; } = "EUR";
        public DateTime Date { get; set; }
        [NotMapped]
        public ErrorTable Error { get; set; } = null!;
        [NotMapped]
        public ICollection<RatesTable> Rates { get; set; } = null!;

    }
}
