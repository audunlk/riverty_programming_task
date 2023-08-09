using CurrencyConverter.ConsoleApp.Models;
using Microsoft.EntityFrameworkCore;
namespace CurrencyConverter.API.Data
{
    public class ExchangeRateDbContextcs
    {
        public class ExchangeRateDbContext : DbContext
        {
            public ExchangeRateDbContext(DbContextOptions<ExchangeRateDbContext> options) : base(options)
            {
            }
            public DbSet<Response> ExchangeRates { get; set; }
        }
    }
}
