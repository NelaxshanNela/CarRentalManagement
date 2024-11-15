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

        public async Task<IEnumerable<Car>> GetAllCars()
        {
            return await _context.Cars.ToListAsync();
        }

        public async Task<IEnumerable<Car>> GetCarsByBrand(string brand)
        {
            return await _context.Cars.Where(c => c.Model.Brand.Name == brand).ToListAsync();
        }

        public async Task<IEnumerable<Car>> GetCarsByModel(string model)
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
            _context.Cars.Update(car);
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

        public async Task<bool> BrandExistsAsync(int brandId)
        {
            return await _context.Brands.AnyAsync(b => b.BrandId == brandId);
        }

        public async Task<bool> ModelExistsAsync(int modelId)
        {
            return await _context.Models.AnyAsync(m => m.ModelId == modelId);
        }

        //public async Task<int> GetCarViewCountAsync(int carId)
        //{
        //    return await _context.CarViews
        //        .Where(cv => cv.CarId == carId)
        //        .CountAsync();
        //}

        //public async Task IncrementCarViewCountAsync(int carId)
        //{
        //    var carView = new CarView
        //    {
        //        CarId = carId,
        //        UserId = 0, // Assuming you don't want to track per user
        //        ViewedAt = DateTime.UtcNow
        //    };

        //    await _context.CarViews.AddAsync(carView);
        //    await _context.SaveChangesAsync();
        //}
    }

}
