using CarRendalAPI.Models;

namespace CarRendalAPI.IRepositories
{
    public interface IPaymentRepository
    {
        Task<Payment> GetPaymentById(int id);
        Task<IEnumerable<Payment>> GetPaymentsByRentalId(int rentalId);
        Task<Payment> AddPayment(Payment payment);
        Task<Payment> UpdatePayment(Payment payment);
        Task<bool> DeletePayment(int id);
        Task<decimal> GetTotalPaymentsForRental(int rentalId);
    }
}
