using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ProductRegistrySystem.Persistence.Entities;
using ProductRegistrySystem.Persistence.Utils;

namespace ProductRegistrySystem.Persistence
{
    public class ProductRegistrySystemDbContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public ProductRegistrySystemDbContext(IConfiguration configuration)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product>()
                .HasData(DataSeeding.SeedProductData());
        }
    }
}
