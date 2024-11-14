//using CarRendalAPI.IRepositories;
//using CarRendalAPI.IServices;
//using CarRendalAPI.Models;

//namespace CarRendalAPI.Services
//{
//    public class PaymentService : IPaymentService
//    {
//        private readonly IPaymentRepository _paymentRepository;

//        public PaymentService(IPaymentRepository paymentRepository)
//        {
//            _paymentRepository = paymentRepository;
//        }

//        public async Task<Payment> GetPaymentByIdAsync(int id)
//        {
//            return await _paymentRepository.GetPaymentByIdAsync(id);
//        }

//        public async Task<IEnumerable<Payment>> GetPaymentsByRentalIdAsync(int rentalId)
//        {
//            return await _paymentRepository.GetPaymentsByRentalIdAsync(rentalId);
//        }

//        public async Task CreatePaymentAsync(Payment payment)
//        {
//            // Add business logic, e.g., ensure payment amount is correct
//            if (payment.Amount <= 0)
//            {
//                throw new ArgumentException("Payment amount must be greater than zero.");
//            }

//            await _paymentRepository.AddPaymentAsync(payment);
//        }

//        public async Task UpdatePaymentAsync(Payment payment)
//        {
//            // Additional business logic can be added here, such as ensuring a payment hasn't already been processed.
//            await _paymentRepository.UpdatePaymentAsync(payment);
//        }

//        public async Task DeletePaymentAsync(int id)
//        {
//            await _paymentRepository.DeletePaymentAsync(id);
//        }

//        public async Task<decimal> GetTotalPaymentsForRentalAsync(int rentalId)
//        {
//            return await _paymentRepository.GetTotalPaymentsForRentalAsync(rentalId);
//        }
//    }

//}
