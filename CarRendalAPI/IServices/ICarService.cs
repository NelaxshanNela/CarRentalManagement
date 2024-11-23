using CarRendalAPI.DTOs.RequestDTOs;
using CarRendalAPI.DTOs.ResponceDTOs;
using CarRendalAPI.Models;

namespace CarRendalAPI.IServices
{
    public interface ICarService
    {
        Task<Car> GetCarById(int id);
        Task<List<Car>> GetAllCars();
        Task<List<Car>> GetCarsByBrand(string brand);
        Task<List<Car>> GetCarsByModel(string model);
        Task<string> CreateCar(CarReqDTO carReqDTO);
        Task<string> UpdateCar(int id, CarReqDTO carReqDTO);
        Task<bool> DeleteCar(int id);
        Task IncrementCarViewCount(int carId);
    }
}
