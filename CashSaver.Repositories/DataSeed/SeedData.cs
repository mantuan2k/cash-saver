using CashSaver.Domain;
using Microsoft.EntityFrameworkCore;

namespace CashSaver.Repositories.DataSeed
{
    public static class SeedData
    {
        public static void SeedBills(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bill>().HasData(
               new Bill("Teste 1", 100.00M),
               new Bill("Teste 2", 100.00M, "Descrição 2", DateTime.Now, DateTime.Now.AddMonths(2)),
               new Bill("Teste 3", 100.00M, "Descrição 3", DateTime.Now),
               new Bill("Teste 4", 100.00M, "Descrição 4")
            );
        }
    }
}
