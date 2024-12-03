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

        public async Task<List<Car>> GetAllCars()
        {
            var cars = await _carRepository.GetAllCars();
            if (cars == null) throw new KeyNotFoundException("No Cars available.");
            return cars;
        }

        public async Task<List<Car>> GetCarsByBrand(string brand)
        {
            var cars = await _carRepository.GetCarsByBrand(brand);
            if (cars == null) throw new KeyNotFoundException("No Cars available.");
            return cars;
        }

        public async Task<List<Car>> GetCarsByModel(string model)
        {
            var cars = await _carRepository.GetCarsByModel(model);
            if (cars == null) throw new KeyNotFoundException("No Cars available.");
            return cars;
        }

        public async Task<string> CreateCar(CarReqDTO carReqDTO)
        {
            var existingCar = await _carRepository.GetModelByLicensePlate(carReqDTO.LicensePlate);
            if (existingCar != null)
            {
                throw new ArgumentException("This Car is already registered.");
            }

            var modelExists = await _carRepository.ModelExistsAsync(carReqDTO.ModelId);
            if (!modelExists)
            {
                throw new ArgumentException($"Model with ID {carReqDTO.ModelId} does not exist.");
            }

            var car = new Car
            {
                Name = carReqDTO.Name,
                LicensePlate = carReqDTO.LicensePlate,
                Color = carReqDTO.Color,
                Status = carReqDTO.Status,
                PricePerDay = carReqDTO.PricePerDay,
                CurrentMileage = carReqDTO.CurrentMileage,
                RegistrationNumber = carReqDTO.RegistrationNumber,
                YearOfManufacture = carReqDTO.YearOfManufacture,
                ModelId = carReqDTO.ModelId,
                TankCapacity = carReqDTO.TankCapacity,
                FrotView = carReqDTO.FrotView,
                BackView = carReqDTO.BackView,
                SideView = carReqDTO.SideView,
                Interior = carReqDTO.Interior

            };
            var data = await _carRepository.CreateCar(car);

            return "Car added succesfully";
        }

        public async Task<string> UpdateCar(int id, CarReqDTO carReqDTO)
        {
            var modelExists = await _carRepository.ModelExistsAsync(carReqDTO.ModelId);
            if (!modelExists)
            {
                throw new ArgumentException($"Model with ID {carReqDTO.ModelId} does not exist.");
            }

            var existingCar = await _carRepository.GetCarById(id);
            if (existingCar == null)
            {
                throw new KeyNotFoundException("Car not found.");
            }


            existingCar.Name = carReqDTO.Name;
            existingCar.LicensePlate = carReqDTO.LicensePlate;
            existingCar.Color = carReqDTO.Color;
            existingCar.Status = carReqDTO.Status;
            existingCar.PricePerDay = carReqDTO.PricePerDay;
            existingCar.CurrentMileage = carReqDTO.CurrentMileage;
            existingCar.RegistrationNumber = carReqDTO.RegistrationNumber;
            existingCar.YearOfManufacture = carReqDTO.YearOfManufacture;
            existingCar.ModelId = carReqDTO.ModelId;
            existingCar.TankCapacity = carReqDTO.TankCapacity;
            existingCar.FrotView = carReqDTO.FrotView;
            existingCar.BackView = carReqDTO.BackView;
            existingCar.SideView = carReqDTO.SideView;
            existingCar.Interior = carReqDTO.Interior;

            var data = await _carRepository.UpdateCar(existingCar);

            return "Car updated successfully";
        }

        public async Task<bool> DeleteCar(int id)
        {
            var success = await _carRepository.DeleteCar(id);
            if (!success) throw new KeyNotFoundException("Car not found.");
            return success;
        }

        public async Task IncrementCarViewCount(int carId)
        {
            await _carRepository.IncrementViewCount(carId);
        }
    }
}
