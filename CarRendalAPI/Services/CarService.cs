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

            var imageList = new List<CarImages>();

            foreach (var item in carReqDTO.CarImages)
            {
                var image = new CarImages();
                image.ImageUrl = item.ImageUrl;
                image.ImageType = item.ImageType;
                image.CarId = data.CarId;
                image.CarId = data.CarId;
                image.CreatedAt = DateTime.UtcNow;
                imageList.Add(image);
            }

            await _carRepository.AddImage(imageList);

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

            var existingImages = await _carRepository.GetImageByCarId(id);

            //var imagesToDelete = existingImages.Where(image => !carReqDTO.CarImages.Any(newImage => newImage.ImageUrl == image.ImageUrl)).ToList();
            //if (imagesToDelete.Any())
            //{
            //    await _carRepository.DeleteImages(imagesToDelete);
            //}

            var imageList = new List<CarImages>();

            foreach (var item in carReqDTO.CarImages)
            {
                var existingImage = existingImages.FirstOrDefault(image => image.ImageType == item.ImageType);
                if (existingImage != null)
                {
                    existingImage.ImageUrl = item.ImageUrl;
                    existingImage.UpdatedAt = DateTime.UtcNow;
                    await _carRepository.UpdateImage(existingImage);
                }
                else
                {
                    var image = new CarImages
                    {
                        ImageUrl = item.ImageUrl,
                        ImageType = item.ImageType,
                        CarId = data.CarId,
                        CreatedAt = DateTime.UtcNow
                    };
                    imageList.Add(image);
                }
            }

            if (imageList.Any())
            {
                await _carRepository.AddImage(imageList);
            }

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
