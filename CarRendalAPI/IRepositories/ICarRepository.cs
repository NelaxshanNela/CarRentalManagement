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
        Task<Car> UpdateCar(int id, Car car);
        Task DeleteCar(int id);

        //Task<int> GetCarViewCountAsync(int carId);
        //Task IncrementCarViewCountAsync(int carId);
    }
}
