using CarRendalAPI.Database;
using CarRendalAPI.IRepositories;
using CarRendalAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CarRendalAPI.Repositories
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly ApplicationDbContext _context;

        public PaymentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Payment>> GetAllPayment()
        {
            return await _context.Payments.ToListAsync();
        }

        public async Task<Payment> GetPaymentById(int id)
        {
            return await _context.Payments.FirstOrDefaultAsync(p => p.PaymentId == id);
        }

        public async Task<IEnumerable<Payment>> GetPaymentsByRentalId(int rentalId)
        {
            return await _context.Payments.Where(p => p.RentalId == rentalId).Include(p => p.Rental).ToListAsync();
        }

        public async Task<Payment> AddPayment(Payment payment)
        {
            await _context.Payments.AddAsync(payment);
            await _context.SaveChangesAsync();
            return payment;
        }

        public async Task<Payment> UpdatePayment(Payment payment)
        {
            _context.Payments.Update(payment);
            await _context.SaveChangesAsync();
            return payment;
        }

        public async Task<bool> DeletePayment(int id)
        {
            var payment = await _context.Payments.FindAsync(id);
            if (payment == null) return false;

            _context.Payments.Remove(payment);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<decimal> GetTotalPaymentsForRental(int rentalId)
        {
            return await _context.Payments.Where(p => p.RentalId == rentalId).SumAsync(p => p.Amount);
        }
    }

}
