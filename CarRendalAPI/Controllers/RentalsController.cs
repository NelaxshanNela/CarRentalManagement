//using CarRendalAPI.IServices;
//using CarRendalAPI.Models;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;

//namespace CarRendalAPI.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class RentalsController : ControllerBase
//    {
//        private readonly IRentalService _rentalService;

//        public RentalsController(IRentalService rentalService)
//        {
//            _rentalService = rentalService;
//        }

//        // GET: api/Rentals
//        [HttpGet]
//        public async Task<ActionResult<IEnumerable<Rental>>> GetRentals()
//        {
//            var rentals = await _rentalService.GetAllRentalsAsync();
//            return Ok(rentals);
//        }

//        // GET: api/Rentals/5
//        [HttpGet("{id}")]
//        public async Task<ActionResult<Rental>> GetRental(int id)
//        {
//            var rental = await _rentalService.GetRentalByIdAsync(id);

//            if (rental == null)
//            {
//                return NotFound();
//            }

//            return Ok(rental);
//        }

//        // GET: api/Rentals/User/5
//        [HttpGet("User/{userId}")]
//        public async Task<ActionResult<IEnumerable<Rental>>> GetRentalsByUser(int userId)
//        {
//            var rentals = await _rentalService.GetRentalsByUserIdAsync(userId);
//            return Ok(rentals);
//        }

//        // GET: api/Rentals/Car/5
//        [HttpGet("Car/{carId}")]
//        public async Task<ActionResult<IEnumerable<Rental>>> GetRentalsByCar(int carId)
//        {
//            var rentals = await _rentalService.GetRentalsByCarIdAsync(carId);
//            return Ok(rentals);
//        }

//        // POST: api/Rentals
//        [HttpPost]
//        public async Task<ActionResult<Rental>> CreateRental(Rental rental)
//        {
//            // You can validate the rental data here, such as checking if the car is available
//            await _rentalService.CreateRentalAsync(rental);
//            return CreatedAtAction(nameof(GetRental), new { id = rental.RentalId }, rental);
//        }

//        // PUT: api/Rentals/5
//        [HttpPut("{id}")]
//        public async Task<IActionResult> UpdateRental(int id, Rental rental)
//        {
//            if (id != rental.RentalId)
//            {
//                return BadRequest();
//            }

//            await _rentalService.UpdateRentalAsync(rental);
//            return NoContent();
//        }

//        // DELETE: api/Rentals/5
//        [HttpDelete("{id}")]
//        public async Task<IActionResult> DeleteRental(int id)
//        {
//            await _rentalService.DeleteRentalAsync(id);
//            return NoContent();
//        }

//        // GET: api/Rentals/TotalRentalsForCar/5
//        [HttpGet("TotalRentalsForCar/{carId}")]
//        public async Task<ActionResult<int>> GetTotalRentalsForCar(int carId)
//        {
//            var totalRentals = await _rentalService.GetTotalRentalsForCarAsync(carId);
//            return Ok(totalRentals);
//        }
//    }

//}
