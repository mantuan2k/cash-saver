using CashSaver.Domain;
using CashSaver.Repositories.DataSeed;
using CashSaver.Repositories.Mapping;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;

namespace CashSaver.Repositories
{
    public class CashSaverContext : DbContext
    {
        public CashSaverContext() : base()
        { }

        public CashSaverContext(DbContextOptions options) : base(options)
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
            optionsBuilder.UseSqlServer(GetConnectionString());
        }

        private static string GetConnectionString()
        {
            var storedConnectionString = Environment.GetEnvironmentVariable("connection");

            return string.IsNullOrWhiteSpace(storedConnectionString)
                ? "Server=(localdb)\\mssqllocaldb;Database=DefaultDB;Trusted_Connection=True;"
                : storedConnectionString;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            SeedData.SeedBills(modelBuilder);
            CashSaverMapping.InitializeMapping(modelBuilder);
        }
        private string? _connectionString;
        public DbSet<Bill>? Bill { get; set; }
    }
}