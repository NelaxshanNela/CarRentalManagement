using CarRendalAPI.IRepositories;
using CarRendalAPI.IServices;
using CarRendalAPI.Models;

namespace CarRendalAPI.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentRepository _paymentRepository;

        public PaymentService(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }

        public async Task<Payment> GetPaymentById(int id)
        {
            return await _paymentRepository.GetPaymentById(id);
        }

        public async Task<IEnumerable<Payment>> GetPaymentsByRentalId(int rentalId)
        {
            return await _paymentRepository.GetPaymentsByRentalId(rentalId);
        }

        public async Task CreatePayment(Payment payment)
        {
            // Add business logic, e.g., ensure payment amount is correct
            if (payment.Amount <= 0)
            {
                throw new ArgumentException("Payment amount must be greater than zero.");
            }

            await _paymentRepository.AddPayment(payment);
        }

        public async Task UpdatePayment(Payment payment)
        {
            // Additional business logic can be added here, such as ensuring a payment hasn't already been processed.
            await _paymentRepository.UpdatePayment(payment);
        }

        public async Task DeletePayment(int id)
        {
            await _paymentRepository.DeletePayment(id);
        }

        public async Task<decimal> GetTotalPaymentsForRental(int rentalId)
        {
            return await _paymentRepository.GetTotalPaymentsForRental(rentalId);
        }
    }

}
