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

        public async Task<IEnumerable<Model>> GetAllModels()
        {
            return await _modelRepository.GetAllModels();
        }

        public async Task<Model> GetModelById(int id)
        {
            var model = await _modelRepository.GetModelById(id);
            if (model == null) throw new KeyNotFoundException("Model not found.");
            return model;
        }

        public async Task<ModelResDTO> CreateModel(ModelReqDTO modelReqDTO)
        {
            var brandExists = await _modelRepository.BrandExistsAsync(modelReqDTO.BrandId);
            if (!brandExists)
            {
                throw new ArgumentException($"Brand with ID {modelReqDTO.BrandId} does not exist.");
            }

            var model = new Model
            {
                Name = modelReqDTO.Name,
                Year = modelReqDTO.Year,
                Color = modelReqDTO.Color,
                EngineType = modelReqDTO.EngineType,
                FuelType = modelReqDTO.FuelType,
                FuelEfficiency = modelReqDTO.FuelEfficiency,
                TransmissionType = modelReqDTO.TransmissionType,
                Mileage = modelReqDTO.Mileage,
                Horsepower = modelReqDTO.Horsepower,
                Doors = modelReqDTO.Doors,
                Seats = modelReqDTO.Seats,
                IsElectric = modelReqDTO.IsElectric,
                Category = modelReqDTO.Category,
                BrandId = modelReqDTO.BrandId,
            };

            var data = await _modelRepository.CreateModel(model);

            var responce = new ModelResDTO
            {
                ModelId = data.ModelId,
                Name = data.Name,
                Year = data.Year,
                Color = data.Color,
                EngineType = data.EngineType,
                FuelType = data.FuelType,
                FuelEfficiency = data.FuelEfficiency,
                TransmissionType = data.TransmissionType,
                Mileage = data.Mileage,
                Horsepower = data.Horsepower,
                Doors = data.Doors,
                Seats = data.Seats,
                IsElectric = data.IsElectric,
                Category = data.Category,
                Brand = data.Brand,
                Cars = data.Cars
            };
            return responce;
        }

        public async Task<ModelResDTO> UpdateModel(int id, ModelReqDTO modelReqDTO)
        {
            if (id != modelReqDTO.ModelId)
            {
                throw new ArgumentException("The ID in the URL does not match the ID in the body.");
            }

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
            existingModel.Color = modelReqDTO.Color;
            existingModel.EngineType = modelReqDTO.EngineType;
            existingModel.FuelType = modelReqDTO.FuelType;
            existingModel.FuelEfficiency = modelReqDTO.FuelEfficiency;
            existingModel.TransmissionType = modelReqDTO.TransmissionType;
            existingModel.Mileage = modelReqDTO.Mileage;
            existingModel.Horsepower = modelReqDTO.Horsepower;
            existingModel.Doors = modelReqDTO.Doors;
            existingModel.Seats = modelReqDTO.Seats;
            existingModel.IsElectric = modelReqDTO.IsElectric;
            existingModel.Category = modelReqDTO.Category;
            existingModel.BrandId = modelReqDTO.BrandId;

            var data = await _modelRepository.UpdateModel(existingModel);

            var responce = new ModelResDTO
            {
                ModelId = data.ModelId,
                Name = data.Name,
                Year = data.Year,
                Color = data.Color,
                EngineType = data.EngineType,
                FuelType = data.FuelType,
                FuelEfficiency = data.FuelEfficiency,
                TransmissionType = data.TransmissionType,
                Mileage = data.Mileage,
                Horsepower = data.Horsepower,
                Doors = data.Doors,
                Seats = data.Seats,
                IsElectric = data.IsElectric,
                Category = data.Category,
                Brand = data.Brand,
                Cars = data.Cars
            };
            return responce;
        }

        public async Task<bool> DeleteModel(int id)
        {
            var success = await _modelRepository.DeleteModel(id);
            if (!success) throw new KeyNotFoundException("Model not found.");
            return success;
        }
    }
}
