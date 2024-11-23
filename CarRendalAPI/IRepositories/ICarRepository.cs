using CarRendalAPI.Models;

namespace CarRendalAPI.IRepositories
{
    public interface ICarRepository
    {
        Task<Car> GetCarById(int id);
        Task<List<Car>> GetAllCars();
        Task<List<Car>> GetCarsByBrand(string brand);
        Task<List<Car>> GetCarsByModel(string model);
        Task<Car> GetModelByLicensePlate(string licensePlate);
        Task<Car> CreateCar(Car car);
        Task<Car> UpdateCar(Car car);
        Task<bool> DeleteCar(int id);
        Task<bool> ModelExistsAsync(int modelId);
        Task<List<CarImages>> AddImage(List<CarImages> image);
        Task<List<CarImages>> UpdateImage(List<CarImages> image);
        Task<List<UserImages>> GetImageByCarId(int id);
        //Task<int> GetViewCountAsync(int carId);
        Task IncrementViewCount(int carId);
    }
}
