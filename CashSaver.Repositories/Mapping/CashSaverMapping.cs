using CashSaver.Domain;
using CashSaver.Helper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CashSaver.Repositories.Mapping
{
    public static class CashSaverMapping
    {
        public static void InitializeMapping(ModelBuilder modelBuilder)
        {
            BillMapping(modelBuilder.Entity<Bill>());
        }

        private static void BillMapping(EntityTypeBuilder<Bill> entity)
        {
            entity.ToTable("Bill");

            entity.HasKey(e => e.Id);

            entity.Property(e => e.Description);
            entity.Property(e => e.Title).IsRequired();
            entity.Property(e => e.Price).IsRequired();
            entity.Property(e => e.PaidDate);
            entity.Property(e => e.ExpirationDate);
            entity.Property(e => e.CreatedAt);
            entity.Property(e => e.LastModifiedAt);
        }
    }
}
