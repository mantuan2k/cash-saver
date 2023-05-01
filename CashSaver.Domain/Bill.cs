using CashSaver.Helper;

namespace CashSaver.Domain
{
    public class Bill : AuditableEntity
    {
        public Bill(string title, decimal price, string? description = null, DateTime? paidDate = null, DateTime? expirationDate = null)
        {
            Id = Guid.NewGuid();
            Title = title;
            Description = description;
            Price = price;
            PaidDate = paidDate;
            ExpirationDate = expirationDate;
            CreatedAt = DateTime.UtcNow;
        }

        public Result<string> SetTitle(string value)
        {
            var result = new Result<string>();
            if(string.IsNullOrWhiteSpace(value))
            {
                return result.CreateFailureResult($"O campo {nameof(value)} não pode ser vazio");
            }
            Title = value;
            LastModifiedAt = DateTime.Now;

            return result.CreateSuccessResult(value); ;
        }

        public Result<string> SetDescription(string value)
        {
            var result = new Result<string>();
            if (string.IsNullOrWhiteSpace(value))
            {
                return result.CreateFailureResult($"O campo {nameof(value)} não pode ser vazio");
            }

            Description = value;
            LastModifiedAt = DateTime.Now;

            return result.CreateSuccessResult(value); ;
        }

        public Result<decimal> SetPrice(decimal value)
        {
            var result = new Result<decimal>();
            if (Price < 0)
            {
                return result.CreateFailureResult($"O campo {nameof(value)} não pode ser negativo");
            }
            Price = value;
            LastModifiedAt = DateTime.Now;

            return result.CreateSuccessResult(value); ;
        }

        public Result<DateTime> SetPaidDate(DateTime value)
        {
            var result = new Result<DateTime>();
            // TODO: Add validations if needed
            PaidDate = value;
            LastModifiedAt = DateTime.Now;

            return result.CreateSuccessResult(value); ;
        }

        public Result<DateTime> SetExpirationDate(DateTime value)
        {
            var result = new Result<DateTime>();
            // TODO: Add validations if needed
            ExpirationDate = value;
            LastModifiedAt = DateTime.Now;

            return result.CreateSuccessResult(value); ;
        }

        public string Title { get; private set; }
        public string? Description { get; private set; }
        public decimal Price { get; private set; }
        public DateTime? PaidDate { get; private set; }
        public DateTime? ExpirationDate { get; private set; }
        public bool IsPaid => PaidDate.HasValue;
    }
}