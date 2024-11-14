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
            return await _context.Cars.Include(c => c.Model).Include(c => c.CarImages).Include(c => c.Model.Brand).FirstOrDefaultAsync(c => c.CarId == id);
        }

        public async Task<IEnumerable<Car>> GetAllCars()
        {
            return await _context.Cars.Include(c => c.Model).Include(c => c.CarImages).Include(c => c.Model.Brand).ToListAsync();
        }

        public async Task<IEnumerable<Car>> GetCarsByBrand(string brand)
        {
            return await _context.Cars.Where(c => c.Model.Brand.Name == brand).Include(c => c.Model).Include(c => c.Model.Brand).ToListAsync();
        }

        public async Task<IEnumerable<Car>> GetCarsByModel(string model)
        {
            return await _context.Cars.Where(c => c.Model.Name == model).Include(c => c.Model).Include(c => c.Model.Brand).ToListAsync();
        }

        public async Task<Car> CreateCar(Car car)
        {
            await _context.Cars.AddAsync(car);
            await _context.SaveChangesAsync();
            return car;
        }

        public async Task<Car> UpdateCar(int id, Car car)
        {
            var data = await _context.Cars.FindAsync(id);
            if (data == null)
            {
                return null;
            }

            _context.Cars.Update(car);
            await _context.SaveChangesAsync();

            return car;
        }

        public async Task DeleteCar(int id)
        {
            var car = await _context.Cars.FindAsync(id);
            if (car != null)
            {
                _context.Cars.Remove(car);
                await _context.SaveChangesAsync();
            }
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
