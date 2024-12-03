using CarRendalAPI.Database;
using CarRendalAPI.IRepositories;
using CarRendalAPI.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace CarRendalAPI.Repositories
{
    public class CarRepository : ICarRepository
    {
        private readonly ApplicationDbContext _context;

        public CarRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Car> GetCarById(int id)
        {
            return await _context.Cars.FirstOrDefaultAsync(c => c.CarId == id);
        }

        public async Task<Car> GetModelByLicensePlate(string licensePlate)
        {
            return await _context.Cars.FirstOrDefaultAsync(c => c.LicensePlate == licensePlate);
        }

        public async Task<List<Car>> GetAllCars()
        {
            return await _context.Cars.Include(c => c.Reviews).ToListAsync();
        }

        public async Task<List<Car>> GetCarsByBrand(string brand)
        {
            return await _context.Cars.Where(c => c.Model.Brand.Name == brand).ToListAsync();
        }

        public async Task<List<Car>> GetCarsByModel(string model)
        {
            return await _context.Cars.Where(c => c.Model.Name == model).ToListAsync();
        }

        public async Task<Car> CreateCar(Car car)
        {
            _context.Cars.Add(car);
            await _context.SaveChangesAsync();
            return car;
        }

        public async Task<Car> UpdateCar(Car car)
        {
            _context.Cars.UpdateRange(car);
            await _context.SaveChangesAsync();
            return car;
        }

        public async Task<bool> DeleteCar(int id)
        {
            var car = await _context.Cars.FindAsync(id);
            if (car == null) return false;

            _context.Cars.Remove(car);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ModelExistsAsync(int modelId)
        {
            return await _context.Models.AnyAsync(m => m.ModelId == modelId);
        }

        public async Task IncrementViewCount(int carId)
        {
            var car = await _context.Cars
                .FirstOrDefaultAsync(c => c.CarId == carId);

            if (car != null)
            {
                car.ViewCount++;
                await _context.SaveChangesAsync();
            }
        }
    }
}
