using CarRendalAPI.Models;

namespace CarRendalAPI.IRepositories
{
    public interface ICarRepository
    {
        Task<Car> GetCarById(int id);
        Task<IEnumerable<Car>> GetAllCars();
        Task<IEnumerable<Car>> GetCarsByBrand(string brand);
        Task<IEnumerable<Car>> GetCarsByModel(string model);
        Task<Car> CreateCar(Car car);
        Task<Car> UpdateCar(Car car);
        Task<bool> DeleteCar(int id);
        Task<bool> BrandExistsAsync(int brandId);
        Task<bool> ModelExistsAsync(int modelId);
    }
}
