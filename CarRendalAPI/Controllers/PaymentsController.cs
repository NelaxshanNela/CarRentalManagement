//using CarRendalAPI.IServices;
//using CarRendalAPI.Models;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;

//namespace CarRendalAPI.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class PaymentsController : ControllerBase
//    {
//        private readonly IPaymentService _paymentService;

//        public PaymentsController(IPaymentService paymentService)
//        {
//            _paymentService = paymentService;
//        }

//        // GET: api/Payments
//        [HttpGet]
//        public async Task<ActionResult<IEnumerable<Payment>>> GetPayments()
//        {
//            var payments = await _paymentService.GetPaymentsByRentalIdAsync(0); // You could return all payments here if needed
//            return Ok(payments);
//        }

//        // GET: api/Payments/5
//        [HttpGet("{id}")]
//        public async Task<ActionResult<Payment>> GetPayment(int id)
//        {
//            var payment = await _paymentService.GetPaymentByIdAsync(id);

//            if (payment == null)
//            {
//                return NotFound();
//            }

//            return Ok(payment);
//        }

//        // GET: api/Payments/Rental/5
//        [HttpGet("Rental/{rentalId}")]
//        public async Task<ActionResult<IEnumerable<Payment>>> GetPaymentsByRental(int rentalId)
//        {
//            var payments = await _paymentService.GetPaymentsByRentalIdAsync(rentalId);
//            return Ok(payments);
//        }

//        // POST: api/Payments
//        [HttpPost]
//        public async Task<ActionResult<Payment>> CreatePayment(Payment payment)
//        {
//            try
//            {
//                await _paymentService.CreatePaymentAsync(payment);
//                return CreatedAtAction(nameof(GetPayment), new { id = payment.PaymentId }, payment);
//            }
//            catch (ArgumentException ex)
//            {
//                return BadRequest(ex.Message);
//            }
//        }

//        // PUT: api/Payments/5
//        [HttpPut("{id}")]
//        public async Task<IActionResult> UpdatePayment(int id, Payment payment)
//        {
//            if (id != payment.PaymentId)
//            {
//                return BadRequest();
//            }

//            await _paymentService.UpdatePaymentAsync(payment);
//            return NoContent();
//        }

//        // DELETE: api/Payments/5
//        [HttpDelete("{id}")]
//        public async Task<IActionResult> DeletePayment(int id)
//        {
//            await _paymentService.DeletePaymentAsync(id);
//            return NoContent();
//        }

//        // GET: api/Payments/TotalPaymentsForRental/5
//        [HttpGet("TotalPaymentsForRental/{rentalId}")]
//        public async Task<ActionResult<decimal>> GetTotalPaymentsForRental(int rentalId)
//        {
//            var totalPayments = await _paymentService.GetTotalPaymentsForRentalAsync(rentalId);
//            return Ok(totalPayments);
//        }
//    }

//}
