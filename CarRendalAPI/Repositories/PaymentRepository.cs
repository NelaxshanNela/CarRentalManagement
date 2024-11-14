//using CarRendalAPI.Database;
//using CarRendalAPI.IRepositories;
//using CarRendalAPI.Models;
//using Microsoft.EntityFrameworkCore;

//namespace CarRendalAPI.Repositories
//{
//    public class PaymentRepository : IPaymentRepository
//    {
//        private readonly ApplicationDbContext _context;

//        public PaymentRepository(ApplicationDbContext context)
//        {
//            _context = context;
//        }

//        public async Task<Payment> GetPaymentByIdAsync(int id)
//        {
//            return await _context.Payments
//                .Include(p => p.Rental)  // Assuming each payment is related to a rental
//                .FirstOrDefaultAsync(p => p.PaymentId == id);
//        }

//        public async Task<IEnumerable<Payment>> GetPaymentsByRentalIdAsync(int rentalId)
//        {
//            return await _context.Payments
//                .Where(p => p.RentalId == rentalId)
//                .Include(p => p.Rental)
//                .ToListAsync();
//        }

//        public async Task AddPaymentAsync(Payment payment)
//        {
//            await _context.Payments.AddAsync(payment);
//            await _context.SaveChangesAsync();
//        }

//        public async Task UpdatePaymentAsync(Payment payment)
//        {
//            _context.Payments.Update(payment);
//            await _context.SaveChangesAsync();
//        }

//        public async Task DeletePaymentAsync(int id)
//        {
//            var payment = await _context.Payments.FindAsync(id);
//            if (payment != null)
//            {
//                _context.Payments.Remove(payment);
//                await _context.SaveChangesAsync();
//            }
//        }

//        public async Task<decimal> GetTotalPaymentsForRentalAsync(int rentalId)
//        {
//            return await _context.Payments
//                .Where(p => p.RentalId == rentalId)
//                .SumAsync(p => p.Amount);
//        }
//    }

//}
