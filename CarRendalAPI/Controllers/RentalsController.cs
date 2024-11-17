using CarRendalAPI.DTOs.RequestDTOs;
using CarRendalAPI.IServices;
using CarRendalAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarRendalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentalsController : ControllerBase
    {
        private readonly IRentalService _rentalService;

        public RentalsController(IRentalService rentalService)
        {
            _rentalService = rentalService;
        }


        [HttpPost]
        public async Task<IActionResult> CreateRental([FromBody] RentalReqDTO rentalReqDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var rentalResDTO = await _rentalService.CreateRental(rentalReqDTO);

            return CreatedAtAction(nameof(CreateRental), new { id = rentalResDTO.RentalId }, rentalResDTO);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRentals()
        {
             try
            {
                var rentals = await _rentalService.GetAllRentals();
                return Ok(rentals);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRentalById(int id)
        {
            try
            {
                var rental = await _rentalService.GetRentalById(id);
                return Ok(rental);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRental(int id,RentalReqDTO rentalReqDTO)
        {
            try
            {
                var updatedRental = await _rentalService.UpdateRental(id, rentalReqDTO);
                return Ok(updatedRental);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRental(int id)
        {
            try
            {
                await _rentalService.DeleteRental(id);
                return NoContent(); // Return 204 No Content on successful deletion
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetRentalsByUserId(int userId)
        {
            var rentals = await _rentalService.GetRentalsByUserId(userId);
            if (rentals == null)
            {
                return NotFound(new { message = "No rentals found for this user" });
            }

            return Ok(rentals);
        }

        [HttpGet("car/{carId}")]
        public async Task<IActionResult> GetRentalsByCarId(int carId)
        {
            var rentals = await _rentalService.GetRentalsByCarId(carId);
            if (rentals == null)
            {
                return NotFound(new { message = "No rentals found for this car" });
            }

            return Ok(rentals);
        }


        [HttpGet("car/{carId}/total")]
        public async Task<IActionResult> GetTotalRentalsForCar(int carId)
        {
            var totalRentals = await _rentalService.GetTotalRentalsForCar(carId);
            return Ok(totalRentals);
        }
    }

}
