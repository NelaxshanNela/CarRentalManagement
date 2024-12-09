using CarRendalAPI.DTOs.RequestDTOs;
using CarRendalAPI.Models;

namespace CarRendalAPI.IServices
{
    public interface IPaymentService
    {
        Task<IEnumerable<Payment>> GetAllPayments();
        Task<Payment> GetPaymentById(int id);
        Task<IEnumerable<Payment>> GetPaymentsByRentalId(int rentalId);
        Task CreatePayment(PaymentReqDTO paymentReqDTO);
        Task UpdatePayment(Payment payment);
        Task DeletePayment(int id);
        Task<decimal> GetTotalPaymentsForRental(int rentalId);
    }
}
