using CarRendalAPI.DTOs.RequestDTOs;
using CarRendalAPI.DTOs.ResponceDTOs;
using CarRendalAPI.IServices;
using CarRendalAPI.Models;
using CarRendalAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace CarRendalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : Controller
    {
        private readonly IReservationService _reservationService;

        public ReservationController(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        // POST: api/Reservation
        [HttpPost]
        public async Task<IActionResult> CreateReservation(ReservationReqDTO reservationReqDTO)
        {
            try
            {
                var createdReservation = await _reservationService.CreateReservation(reservationReqDTO);
                return CreatedAtAction(nameof(GetReservationById), new { id = createdReservation.ReservationId }, createdReservation);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/Reservation(ById)
        [HttpGet("{id}")]
        public async Task<ActionResult<ReservationResDTO>> GetReservationById(int id)
        {
            var reservation = await _reservationService.GetReservationById(id);
            if (reservation == null)
            {
                return NotFound();
            }
            return Ok(reservation);
        }

        // GET: api/Reservation
        [HttpGet]
        public async Task<IActionResult> GetAllReservation()
        {
            try
            {
                var reservations = await _reservationService.GetAllReservation();
                return Ok(reservations);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/Cars/Update
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateReservation(int id, ReservationReqDTO reservationReqDTO)
        {
            try
            {
                var updatedReservation = await _reservationService.UpdateReservation(id, reservationReqDTO);
                return Ok(updatedReservation);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        // Delete: api/Cars/Delete
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReservation(int id)
        {
            try
            {
                await _reservationService.DeleteReservation(id);
                return NoContent(); // Return 204 No Content on successful deletion
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        // Admin Update Reservation Status
        [HttpPut("{id}/status")]
        public async Task<IActionResult> UpdateReservationStatus(int id,UpdateReservationStatusDTO updateReservationStatusDTO)
        {
            if (updateReservationStatusDTO == null)
            {
                return BadRequest("Invalid status data.");
            }

            var updatedReservation = await _reservationService.UpdateReservationStatus(id, updateReservationStatusDTO);

            if (updatedReservation == null)
            {
                return NotFound($"Reservation with ID {id} not found.");
            }

            return Ok(updatedReservation); // Return the updated reservation
        }

    }
}
