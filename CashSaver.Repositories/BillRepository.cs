using CashSaver.Domain;
using Microsoft.EntityFrameworkCore;

namespace CashSaver.Repositories
{
    public class BillRepository : Repository<Bill>
    {
        public BillRepository(CashSaverContext context) : base(context)
        {
        }
    }
}
