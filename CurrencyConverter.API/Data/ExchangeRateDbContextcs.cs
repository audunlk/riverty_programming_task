using Microsoft.EntityFrameworkCore;
using CurrencyConverter.API.Models;

//public class ResponseStatus
//{
//    public int Id { get; set; }
//    public bool Success { get; set; }
//    public long Timestamp { get; set; }
//    public string Base { get; set; } = "EUR";
//    public DateTime Date { get; set; }
//}
//public class Rates
//{
//    public int Id { get; set; }
//    public string Currency { get; set; } = string.Empty;
//    public decimal Value { get; set; }
//    //ForeginKey to ResponseStatus
//    public int ResponseStatusId { get; set; }
//}

//public class Error
//{
//    public int Id { get; set; }
//    public int Code { get; set; }
//    public string Type { get; set; } = string.Empty;
//    public string Info { get; set; } = string.Empty;
//    //ForeginKey to ResponseStatus
//    public int ResponseStatusId { get; set; }
//}
namespace CurrencyConverter.API.Data
{

        public class ExchangeRateDbContext : DbContext
        {

            public ExchangeRateDbContext(DbContextOptions<ExchangeRateDbContext> options) : base(options)
            {
            }

            public DbSet<ResponseStatus> ResponseStatus { get; set; }
            public DbSet<Rates> Rates { get; set; }
            public DbSet<Error> Errors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ResponseStatus>(entity =>
            {
                  entity.HasKey(e => e.Id);

                entity.Property(e => e.Success).IsRequired();
                entity.Property(e => e.Timestamp);
                entity.Property(e => e.Base);
                entity.Property(e => e.Date);
            });

            modelBuilder.Entity<Rates>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Currency).IsRequired();
                entity.Property(e => e.Value).IsRequired();

                entity.HasOne<ResponseStatus>(e => ResponseStatus)
                    .WithMany()
                    .HasForeignKey(e => e.ResponseStatusId);
            });

            modelBuilder.Entity<Error>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Code).IsRequired();
                entity.Property(e => e.Type).IsRequired();
                entity.Property(e => e.Info).IsRequired();
                entity 
                    .HasOne<ResponseStatus>(e => ResponseStatus)
                    .WithMany() 
                    .HasForeignKey(e => e.ResponseStatusId);
            });

        }


    }
}
