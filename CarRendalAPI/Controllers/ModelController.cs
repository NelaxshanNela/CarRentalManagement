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
    public class ModelController : ControllerBase
    {
        private readonly IModelService _modelService;

        public ModelController(IModelService modelService)
        {
            _modelService = modelService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllModels()
        {
            try
            {
                var models = await _modelService.GetAllModels();
                return Ok(models);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetModelById(int id)
        {
            try
            {
                var model = await _modelService.GetModelById(id);
                return Ok(model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateModel(ModelReqDTO modelReqDTO)
        {
            try
            {
                var addedCarModel = await _modelService.CreateModel(modelReqDTO);
                return Ok(new { success = true, message = "Model added successfully" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = "Error adding model", error = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateModel(int id, ModelReqDTO modelReqDTO)
        {
            try
            {
                var updatedCar = await _modelService.UpdateModel(id, modelReqDTO);
                return Ok(new { success = true, message = "Model updated successfully" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = "Error updating model", error = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteModel(int id)
        {
            try
            {
                await _modelService.DeleteModel(id);
                return Ok(new { success = true, message = "Model deleted successfully" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = "Error deleting model", error = ex.Message });
            }
        }
    }
}
