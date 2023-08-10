using System.ComponentModel.DataAnnotations.Schema;

namespace CurrencyConverter.API.Models
{
    public class RatesTable
    {
        public int Id { get; set; }
        public string Currency { get; set; } = string.Empty;
        public decimal Value { get; set; }

        [ForeignKey("ResponseStatusId")]
        
        public int ResponseStatusId { get; set; }
        //navigation property
        [NotMapped]
        public ResponseStatusTable ResponseStatus { get; set; } = null!;
    }
}
