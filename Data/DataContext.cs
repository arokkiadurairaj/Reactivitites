using Domains;
using Microsoft.EntityFrameworkCore;
using System;

namespace Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<WeatherForecast> WeatherForecasts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WeatherForecast>()
                .HasData(
                    new WeatherForecast { Id = 1, ForeCast = "Sunny" },
                    new WeatherForecast { Id = 2, ForeCast = "Cloudy" },
                    new WeatherForecast { Id = 3, ForeCast = "Rainy" }
                );
        }
    }
}

