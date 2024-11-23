using CarRendalAPI.Database;
using CarRendalAPI.IRepositories;
using CarRendalAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CarRendalAPI.Repositories
{
    public class BrandRepository : IBrandRepository
    {
        private readonly ApplicationDbContext _context;
        public BrandRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<Brand>> GetAllBrands()
        {
            return await _context.Brands.Include(b => b.Models).ToListAsync();
        }

        public async Task<Brand> GetBrandById(int id)
        {
            return await _context.Brands.FindAsync(id);
        }

        public async Task<Brand> GetBrandByName(string name)
        {
            return await _context.Brands.FirstOrDefaultAsync(b => b.Name == name);
        }

        public async Task<Brand> CreateBrand(Brand brand)
        {
            await _context.Brands.AddAsync(brand);
            await _context.SaveChangesAsync();
            return brand;
        }

        public async Task<Brand> UpdateBrand(Brand brand)
        {

            _context.Brands.Update(brand);
            await _context.SaveChangesAsync();

            return brand;
        }

        public async Task<bool> DeleteBrand(int id)
        {
            var brand = await _context.Brands.FindAsync(id);
            if (brand != null)
            {
                _context.Brands.Remove(brand);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
