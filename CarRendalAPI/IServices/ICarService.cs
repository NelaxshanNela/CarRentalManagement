using CarRendalAPI.DTOs.RequestDTOs;
using CarRendalAPI.DTOs.ResponceDTOs;
using CarRendalAPI.Models;

namespace CarRendalAPI.IServices
{
    public interface ICarService
    {
        Task<Car> GetCarById(int id);
        Task<IEnumerable<Car>> GetAllCars();
        Task<IEnumerable<Car>> GetCarsByBrand(string brand);
        Task<IEnumerable<Car>> GetCarsByModel(string model);
        Task<Car> CreateCar(CarReqDTO carReqDTO);
        Task<Car> UpdateCar(int id, CarReqDTO carReqDTO);
        Task<bool> DeleteCar(int id);
        //Task<int> GetCarViewCountAsync(int carId);
        //Task IncrementCarViewCountAsync(int carId);
    }
}
