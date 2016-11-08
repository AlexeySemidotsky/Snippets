using System.Data.Entity;

namespace EntityFrameworkBasedService.Context
{
    public class PaymentsDbContext : DbContext
    {
        public PaymentsDbContext(string nameOrConnectionString = "Payments")
            : base(nameOrConnectionString)
        {

        }

        public IDbSet<CustomerCommission> Commissions { get; set; }
    }
}
