using CarRendalAPI.DTOs.RequestDTOs;
using CarRendalAPI.DTOs.ResponceDTOs;
using CarRendalAPI.IServices;
using CarRendalAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarRendalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly IBrandService _brandService;

        public BrandController(IBrandService brandService)
        {
            _brandService = brandService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBrands()
        {
            try
            {
                var brands = await _brandService.GetAllBrands();
                return Ok(brands);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBrandById(int id)
        {
            try
            {
                var brand = await _brandService.GetBrandById(id);
                return Ok(brand);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateBrand(BrandReqDTO brandReqDTO)
        {
            try
            {
                var createdCarBrand = await _brandService.CreateBrand(brandReqDTO);
                return Ok(createdCarBrand);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/carbrand/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCarBrand(int id, BrandReqDTO brandReqDTO)
        {
            try
            {
                var updatedCarBrand = await _brandService.UpdateBrand(id, brandReqDTO);
                return Ok(updatedCarBrand);
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

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBrand(int id)
        {
            try
            {
                await _brandService.DeleteBrand(id);
                return Ok("Brand Deleted Successfully.");
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
