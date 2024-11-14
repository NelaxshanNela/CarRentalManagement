using CarRendalAPI.DTOs.RequestDTOs;
using CarRendalAPI.DTOs.ResponceDTOs;
using CarRendalAPI.IRepositories;
using CarRendalAPI.IServices;
using CarRendalAPI.Models;

namespace CarRendalAPI.Services
{
    public class ModelService : IModelService
    {
        private readonly IModelRepository _modelRepository;

        public ModelService(IModelRepository modelRepository)
        {
            _modelRepository = modelRepository;
        }

        public async Task<ModelResDTO> CreateModel(ModelReqDTO modelReqDTO)
        {
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
                BrandId = data.BrandId,
                Cars = data.Cars
            };
            return responce;
        }

        public async Task<IEnumerable<Model>> GetAllModels()
        {
            return await _modelRepository.GetAllModels();
        }

        public async Task<Model> GetModelById(int id)
        {
            return await _modelRepository.GetModelById(id);
        }

        public async Task<ModelResDTO> UpdateModel(int id, ModelReqDTO modelReqDTO)
        {
            var model = new Model
            {
                ModelId = id,
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
                BrandId = modelReqDTO.BrandId
            };

            var data = await _modelRepository.UpdateModel(id, model);

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
                BrandId = data.BrandId,
                Cars = data.Cars
            };
            return responce;
        }

        public async Task DeleteModel(int id)
        {
            await _modelRepository.DeleteModel(id);
        }
    }
}
