using ProcessPayment.Models;
using System.Threading.Tasks;

namespace ProcessPayment.Repositories
{
    public class PaymentRepository
    {
        private readonly PaymentDbContext _dbContext;

        public PaymentRepository(PaymentDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task InsertPayment(Payment payment)
        {
            _dbContext.Payments.Add(payment);
            await _dbContext.SaveChangesAsync();
        }
    }
}
