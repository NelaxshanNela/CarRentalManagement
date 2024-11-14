using CarRendalAPI.DTOs.RequestDTOs;
using CarRendalAPI.DTOs.ResponceDTOs;
using CarRendalAPI.IRepositories;
using CarRendalAPI.IServices;
using CarRendalAPI.Models;

namespace CarRendalAPI.Services
{
    public class CarService : ICarService
    {
        private readonly ICarRepository _carRepository;

        public CarService(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        public async Task<Car> GetCarById(int id)
        {
            return await _carRepository.GetCarById(id);
        }

        public async Task<IEnumerable<Car>> GetAllCars()
        {
            return await _carRepository.GetAllCars();
        }

        public async Task<IEnumerable<Car>> GetCarsByBrand(string brand)
        {
            return await _carRepository.GetCarsByBrand(brand);
        }

        public async Task<IEnumerable<Car>> GetCarsByModel(string model)
        {
            return await _carRepository.GetCarsByModel(model);
        }

        public async Task<CarResDTO> CreateCar(CarReqDTO carReqDTO)
        {
            var car = new Car
            {
                LicensePlate = carReqDTO.LicensePlate,
                Color = carReqDTO.Color,
                Status = carReqDTO.Status,
                PricePerDay = carReqDTO.PricePerDay,
                CurrentMileage = carReqDTO.CurrentMileage,
                RegistrationNumber = carReqDTO.RegistrationNumber,
                YearOfManufacture = carReqDTO.YearOfManufacture,
                ViewCount = carReqDTO.ViewCount,
                ModelId = carReqDTO.ModelId

            };
            var data = await _carRepository.CreateCar(car);

            var responce = new CarResDTO
            {
                CarId = data.CarId,
                LicensePlate = data.LicensePlate,
                Color = data.Color,
                Status = data.Status,
                PricePerDay = data.PricePerDay,
                CurrentMileage = data.CurrentMileage,
                RegistrationNumber = data.RegistrationNumber,
                YearOfManufacture = data.YearOfManufacture,
                ViewCount = data.ViewCount,
                Model = data.Model,
                CarImages = data.CarImages
            };
            return responce;
        }

        public async Task<CarResDTO> UpdateCar(int id, CarReqDTO carReqDTO)
        {
            var car = new Car
            {
                LicensePlate = carReqDTO.LicensePlate,
                Color = carReqDTO.Color,
                Status = carReqDTO.Status,
                PricePerDay = carReqDTO.PricePerDay,
                CurrentMileage = carReqDTO.CurrentMileage,
                RegistrationNumber = carReqDTO.RegistrationNumber,
                YearOfManufacture = carReqDTO.YearOfManufacture,
                ViewCount = carReqDTO.ViewCount,
                ModelId = carReqDTO.ModelId

            };
            var data = await _carRepository.UpdateCar(id, car);

            var responce = new CarResDTO
            {
                CarId = data.CarId,
                LicensePlate = data.LicensePlate,
                Color = data.Color,
                Status = data.Status,
                PricePerDay = data.PricePerDay,
                CurrentMileage = data.CurrentMileage,
                RegistrationNumber = data.RegistrationNumber,
                YearOfManufacture = data.YearOfManufacture,
                ViewCount = data.ViewCount,
                Model = data.Model,
                CarImages = data.CarImages
            };
            return responce;
        }

        public async Task DeleteCar(int id)
        {
            await _carRepository.DeleteCar(id);
        }

        //public async Task<int> GetCarViewCountAsync(int carId)
        //{
        //    return await _carRepository.GetCarViewCountAsync(carId);
        //}

        //public async Task IncrementCarViewCountAsync(int carId)
        //{
        //    await _carRepository.IncrementCarViewCountAsync(carId);
        //}
    }
}
