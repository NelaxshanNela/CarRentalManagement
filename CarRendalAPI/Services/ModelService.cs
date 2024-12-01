using CarRendalAPI.DTOs.RequestDTOs;
using CarRendalAPI.DTOs.ResponceDTOs;
using CarRendalAPI.IRepositories;
using CarRendalAPI.IServices;
using CarRendalAPI.Models;
using CarRendalAPI.Repositories;

namespace CarRendalAPI.Services
{
    public class ModelService : IModelService
    {
        private readonly IModelRepository _modelRepository;

        public ModelService(IModelRepository modelRepository)
        {
            _modelRepository = modelRepository;
        }

        public async Task<List<Model>> GetAllModels()
        {
            var models = await _modelRepository.GetAllModels();
            if (models == null) throw new KeyNotFoundException("No Models available.");
            return models;
        }

        public async Task<Model> GetModelById(int id)
        {
            var model = await _modelRepository.GetModelById(id);
            if (model == null) throw new KeyNotFoundException("Model not found.");
            return model;
        }

        public async Task<string> CreateModel(ModelReqDTO modelReqDTO)
        {
            var existingModel = await _modelRepository.GetModelByName(modelReqDTO.Name);
            if (existingModel != null)
            {
                throw new ArgumentException("This Model is already registered.");
            }

            var brandExists = await _modelRepository.BrandExistsAsync(modelReqDTO.BrandId);
            if (!brandExists)
            {
                throw new ArgumentException($"Brand with ID {modelReqDTO.BrandId} does not exist.");
            }

            var model = new Model
            {
                Name = modelReqDTO.Name,
                Year = modelReqDTO.Year,
                EngineType = modelReqDTO.EngineType,
                FuelType = modelReqDTO.FuelType,
                TransmissionType = modelReqDTO.TransmissionType,
                Horsepower = modelReqDTO.Horsepower,
                Doors = modelReqDTO.Doors,
                Seats = modelReqDTO.Seats,
                FuelEfficiency = modelReqDTO.FuelEfficiency,
                Category = modelReqDTO.Category,
                CreatedAt = DateTime.UtcNow,
                BrandId = modelReqDTO.BrandId,
            };

            var data = await _modelRepository.CreateModel(model);
            return "Model added successfully";
        }

        public async Task<string> UpdateModel(int id, ModelReqDTO modelReqDTO)
        {
            var existingModel = await _modelRepository.GetModelById(id);
            if (existingModel == null)
            {
                throw new KeyNotFoundException("Model not found.");
            }

            var brandExists = await _modelRepository.BrandExistsAsync(modelReqDTO.BrandId);
            if (!brandExists)
            {
                throw new ArgumentException($"Brand with ID {modelReqDTO.BrandId} does not exist.");
            }

            existingModel.ModelId = id;
            existingModel.Name = modelReqDTO.Name;
            existingModel.Year = modelReqDTO.Year;
            existingModel.EngineType = modelReqDTO.EngineType;
            existingModel.FuelType = modelReqDTO.FuelType;
            existingModel.TransmissionType = modelReqDTO.TransmissionType;
            existingModel.Horsepower = modelReqDTO.Horsepower;
            existingModel.Doors = modelReqDTO.Doors;
            existingModel.Seats = modelReqDTO.Seats;
            existingModel.FuelEfficiency = modelReqDTO.FuelEfficiency;
            existingModel.Category = modelReqDTO.Category;
            existingModel.UpdatedAt = DateTime.UtcNow;
            existingModel.BrandId = modelReqDTO.BrandId;

            var data = await _modelRepository.UpdateModel(existingModel);
            return "Model updated sucessfully";
        }

        public async Task<bool> DeleteModel(int id)
        {
            var success = await _modelRepository.DeleteModel(id);
            if (!success) throw new KeyNotFoundException("Model not found.");
            return success;
        }
    }
}
