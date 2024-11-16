using CarRendalAPI.Models;

namespace CarRendalAPI.IServices
{
    public interface IPaymentService
    {
        Task<Payment> GetPaymentById(int id);
        Task<IEnumerable<Payment>> GetPaymentsByRentalId(int rentalId);
        Task CreatePayment(Payment payment);
        Task UpdatePayment(Payment payment);
        Task DeletePayment(int id);
        Task<decimal> GetTotalPaymentsForRental(int rentalId);
    }
}
