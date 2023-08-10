using System.ComponentModel.DataAnnotations.Schema;

namespace CurrencyConverter.API.Models
{
    public class ErrorTable
    {
        public int Id { get; set; }
        public int Code { get; set; }
        public string Type { get; set; } = string.Empty;
        public string Info { get; set; } = string.Empty;
        [ForeignKey("ResponseStatusId")]
        public int ResponseStatusId { get; set; }
        //navigation property
        [NotMapped]
        public ResponseStatusTable ResponseStatus { get; set; } = null!;

    }
}
