using Microsoft.EntityFrameworkCore;
using CurrencyConverter.API.Models;

namespace CurrencyConverter.API.Data
{
    public class ExchangeRateDbContext : DbContext
        {
            public ExchangeRateDbContext(DbContextOptions<ExchangeRateDbContext> options) : base(options)
            {
            }
            public DbSet<ResponseStatusTable> ResponseStatus { get; set; }
            public DbSet<RatesTable> Rates { get; set; }
            public DbSet<ErrorTable> Errors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ResponseStatusTable>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Success).IsRequired();
                entity.Property(e => e.Timestamp);
                entity.Property(e => e.Base);
                entity.Property(e => e.Date);
            });

            modelBuilder.Entity<RatesTable>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Currency).IsRequired();
                entity.Property(e => e.Value)
                .IsRequired()
                .HasColumnType("decimal")
                .HasPrecision(18, 2);
                entity.HasOne<ResponseStatusTable>(e => e.ResponseStatus)
                    .WithMany(e => e.Rates)
                    .HasForeignKey(e => e.ResponseStatusId);
            });

            modelBuilder.Entity<ErrorTable>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Code).IsRequired();
                entity.Property(e => e.Type).IsRequired();
                entity.Property(e => e.Info).IsRequired();
                entity.HasOne<ResponseStatusTable>(e => e.ResponseStatus)
                    .WithOne(e => e.Error)
                    .HasForeignKey<ErrorTable>(e => e.ResponseStatusId);
            });
        }
    }
}
