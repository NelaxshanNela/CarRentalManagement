using CarRendalAPI.Database;
using CarRendalAPI.IRepositories;
using CarRendalAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CarRendalAPI.Repositories
{
    public class ModelRepository : IModelRepository
    {
        private readonly ApplicationDbContext _context;
        public ModelRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Model>> GetAllModels()
        {
            return await _context.Models.Include(m => m.Cars).ToListAsync();
        }

        public async Task<Model> GetModelById(int id)
        {
            return await _context.Models.FirstOrDefaultAsync(cm => cm.ModelId == id);
        }

        public async Task<Model> GetModelByName(string name)
        {
            return await _context.Models.FirstOrDefaultAsync(b => b.Name == name);
        }

        public async Task<Model> CreateModel(Model model)
        {
            await _context.AddAsync(model);
            await _context.SaveChangesAsync();
            return model;
        }

        public async Task<Model> UpdateModel(Model model)
        {
            _context.Models.Update(model);
            await _context.SaveChangesAsync();
            return model;
        }

        public async Task<bool> DeleteModel(int id)
        {
            var carModel = await _context.Models.FindAsync(id);
            if (carModel == null) return false;

            _context.Models.Remove(carModel);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> BrandExistsAsync(int brandId)
        {
            return await _context.Brands.AnyAsync(b => b.BrandId == brandId);
        }
    }
}