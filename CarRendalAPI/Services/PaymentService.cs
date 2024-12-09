using CarRendalAPI.DTOs.RequestDTOs;
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

        public async Task<IEnumerable<Payment>> GetAllPayments()
        {
            return await _paymentRepository.GetAllPayment();
        }


        public async Task<Payment> GetPaymentById(int id)
        {
            return await _paymentRepository.GetPaymentById(id);
        }

        public async Task<IEnumerable<Payment>> GetPaymentsByRentalId(int rentalId)
        {
            return await _paymentRepository.GetPaymentsByRentalId(rentalId);
        }

        public async Task CreatePayment(PaymentReqDTO paymentReqDTO)
        {
            if (paymentReqDTO.Amount <= 0)
            {
                throw new ArgumentException("Payment amount must be greater than zero.");
            }

            var payment = new Payment
            {
                Amount = paymentReqDTO.Amount,
                PaymentDate = DateTime.UtcNow,
                PaymentMethod = paymentReqDTO.PaymentMethod,
                PaymentStatus = paymentReqDTO.PaymentStatus,
                RentalId = paymentReqDTO.RentalId,

            };

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
