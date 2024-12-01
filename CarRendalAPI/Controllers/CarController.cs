using CarRendalAPI.DTOs.RequestDTOs;
using CarRendalAPI.DTOs.ResponceDTOs;
using CarRendalAPI.IServices;
using CarRendalAPI.Models;
using CarRendalAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarRendalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly ICarService _carService;

        public CarsController(ICarService carService)
        {
            _carService = carService;
        }

        // GET: api/Cars
        [HttpGet]
        public async Task<IActionResult> GetAllCars()
        {
            try
            {
                var cars = await _carService.GetAllCars();
                return Ok(cars);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/Cars/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCarById(int id)
        {
            try
            {
                var car = await _carService.GetCarById(id);

                await _carService.IncrementCarViewCount(id);

                return Ok(car);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/Cars/Brand/{brand}
        [HttpGet("Brand/{brand}")]
        public async Task<IActionResult> GetCarsByBrand(string brand)
        {
            try
            {
                var cars = await _carService.GetCarsByBrand(brand);
                return Ok(cars);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/Cars/Model/{model}
        [HttpGet("Model/{model}")]
        public async Task<IActionResult> GetCarsByModel(string model)
        {
            try
            {
                var cars = await _carService.GetCarsByBrand(model);
                return Ok(cars);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: api/Cars
        [HttpPost]
        public async Task<IActionResult> CreateCar(CarReqDTO carReqDTO)
        {
            try
            {
                var createdCar = await _carService.CreateCar(carReqDTO);
                return Ok(new { success = true, message = "Car added successfully" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = "Error adding Car", error = ex.Message });
            }
        }

        // PUT: api/Cars/Update
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCar(int id, CarReqDTO carReqDTO)
        {
            try
            {
                var updatedCarBrand = await _carService.UpdateCar(id, carReqDTO);
                return Ok(new { success = true, message = "Car updated successfully" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = "Error updating Car", error = ex.Message });
            }
        }

        // DELETE: api/Cars/Delete
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCar(int id)
        {
            try
            {
                await _carService.DeleteCar(id);
                return Ok(new { success = true, message = "Car deleted successfully" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = "Error deleting Car", error = ex.Message });
            }
        }
    }
}
