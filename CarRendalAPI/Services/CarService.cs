using CarRendalAPI.DTOs.RequestDTOs;
using CarRendalAPI.DTOs.ResponceDTOs;
using CarRendalAPI.IRepositories;
using CarRendalAPI.IServices;
using CarRendalAPI.Models;
using CarRendalAPI.Repositories;

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
            var car = await _carRepository.GetCarById(id);
            if (car == null) throw new KeyNotFoundException("Car not found.");
            return car;
        }

        public async Task<IEnumerable<Car>> GetAllCars()
        {
            return await _carRepository.GetAllCars();
        }

        public async Task<IEnumerable<Car>> GetCarsByBrand(string brand)
        {
            var cars = await _carRepository.GetCarsByBrand(brand);
            if (cars == null) throw new KeyNotFoundException("Cars not available.");
            return cars;
        }

        public async Task<IEnumerable<Car>> GetCarsByModel(string model)
        {
            var cars = await _carRepository.GetCarsByModel(model);
            if (cars == null) throw new KeyNotFoundException("Cars not available.");
            return cars;
        }

        public async Task<Car> CreateCar(CarReqDTO carReqDTO)
        {
            var modelExists = await _carRepository.ModelExistsAsync(carReqDTO.ModelId);
            if (!modelExists)
            {
                throw new ArgumentException($"Model with ID {carReqDTO.ModelId} does not exist.");
            }

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

            //var responce = new CarResDTO
            //{
            //    CarId = data.CarId,
            //    LicensePlate = data.LicensePlate,
            //    Color = data.Color,
            //    Status = data.Status,
            //    PricePerDay = data.PricePerDay,
            //    CurrentMileage = data.CurrentMileage,
            //    RegistrationNumber = data.RegistrationNumber,
            //    YearOfManufacture = data.YearOfManufacture,
            //    ViewCount = data.ViewCount,
            //    Model = data.Model,
            //    CarImages = data.CarImages
            //};
            return data;
        }

        public async Task<Car> UpdateCar(int id, CarReqDTO carReqDTO)
        {
            if (id != carReqDTO.CarId)
            {
                throw new ArgumentException("The ID in the URL does not match the ID in the body.");
            }

            var existingCar = await _carRepository.GetCarById(id);
            if (existingCar == null)
            {
                throw new KeyNotFoundException("Car not found.");
            }

            existingCar.CarId = id;
            existingCar.LicensePlate = carReqDTO.LicensePlate;
            existingCar.Color = carReqDTO.Color;
            existingCar.Status = carReqDTO.Status;
            existingCar.PricePerDay = carReqDTO.PricePerDay;
            existingCar.CurrentMileage = carReqDTO.CurrentMileage;
            existingCar.RegistrationNumber = carReqDTO.RegistrationNumber;
            existingCar.YearOfManufacture = carReqDTO.YearOfManufacture;
            existingCar.ViewCount = carReqDTO.ViewCount;
            existingCar.ModelId = carReqDTO.ModelId;

            var data = await _carRepository.UpdateCar(existingCar);

            //var responce = new CarResDTO
            //{
            //    CarId = data.CarId,
            //    LicensePlate = data.LicensePlate,
            //    Color = data.Color,
            //    Status = data.Status,
            //    PricePerDay = data.PricePerDay,
            //    CurrentMileage = data.CurrentMileage,
            //    RegistrationNumber = data.RegistrationNumber,
            //    YearOfManufacture = data.YearOfManufacture,
            //    ViewCount = data.ViewCount,
            //    Model = data.Model,
            //    CarImages = data.CarImages
            //};
            return data;
        }

        public async Task<bool> DeleteCar(int id)
        {
            var success = await _carRepository.DeleteCar(id);
            if(!success) throw new KeyNotFoundException("Car not found.");
            return success;
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
