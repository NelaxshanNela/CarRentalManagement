using CarRendalAPI.DTOs.RequestDTOs;
using CarRendalAPI.IServices;
using CarRendalAPI.Models;
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
        [HttpGet("Get-All-Cars")]
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
        [HttpGet("Get-Car-by-Id-{id}")]
        public async Task<IActionResult> GetCarById(int id)
        {
            try
            {
                var car = await _carService.GetCarById(id);

                if (car == null)
                {
                    return NotFound("Car Not found.");
                }

                // Increment view count when the car details are viewed
                //await _carService.IncrementCarViewCountAsync(id);

                // Optionally, get the current view count to return with the car details
                //var viewCount = await _carService.GetCarViewCountAsync(id);

                return Ok(new
                {
                    Car = car,
                    //ViewCount = viewCount
                });
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
                if (cars == null)
                {
                    return NotFound("Car Not Found");
                }
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
                if (cars == null)
                {
                    return NotFound("Not Found");
                }
                return Ok(cars);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: api/Cars
        [HttpPost("car")]
        public async Task<IActionResult> CreateCar(CarReqDTO carReqDTO)
        {
            try
            {
                var car = await _carService.CreateCar(carReqDTO);
                return Ok(car);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/Cars/Update
        [HttpPut("Edit-Car-{id}")]
        public async Task<IActionResult> UpdateCar(int id, CarReqDTO carReqDTO)
        {
            try
            {
                var data = await _carService.UpdateCar(id, carReqDTO);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // DELETE: api/Cars/Delete
        [HttpDelete("Delete-Car-{id}")]
        public async Task<IActionResult> DeleteCar(int id)
        {
            try
            {
                await _carService.DeleteCar(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
