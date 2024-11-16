using CarRendalAPI.IServices;
using CarRendalAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarRendalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        private readonly IPaymentService _paymentService;

        public PaymentsController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        // GET: api/Payments
        [HttpGet]
        public async Task<IActionResult> GetAllPayments()
        {
            try
            {
                var payments = await _paymentService.GetPaymentsByRentalId(0);
                return Ok(payments);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/Payments/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPaymentById(int id)
        {
            try
            {
                var payment = await _paymentService.GetPaymentById(id);

                if (payment == null)
                {
                    return NotFound();
                }

                return Ok(payment);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/Payments/Rental/5
        [HttpGet("Rental/{rentalId}")]
        public async Task<ActionResult<IEnumerable<Payment>>> GetPaymentsByRental(int rentalId)
        {
            try
            {
                var payments = await _paymentService.GetPaymentsByRentalId(rentalId);
                return Ok(payments);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: api/Payments
        [HttpPost]
        public async Task<IActionResult> CreatePayment(Payment payment)
        {
            try
            {
                await _paymentService.CreatePayment(payment);
                return CreatedAtAction(nameof(GetPaymentById), new { id = payment.PaymentId }, payment);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/Payments/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePayment(int id, Payment payment)
        {
            try
            {
                if (id != payment.PaymentId)
                {
                    return BadRequest();
                }

                await _paymentService.UpdatePayment(payment);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/Payments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePayment(int id)
        {
            try
            {
                await _paymentService.DeletePayment(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/Payments/TotalPaymentsForRental/5
        [HttpGet("TotalPaymentsForRental/{rentalId}")]
        public async Task<IActionResult> GetTotalPaymentsForRental(int rentalId)
        {
            try
            {
                var totalPayments = await _paymentService.GetTotalPaymentsForRental(rentalId);
                return Ok(totalPayments);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
