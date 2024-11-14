﻿using CarRendalAPI.Database;
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

        public async Task<IEnumerable<Model>> GetAllModels()
        {
            return await _context.Models.ToListAsync();
        }

        public async Task<Model> GetModelById(int id)
        {
            return await _context.Models.FirstOrDefaultAsync(b => b.ModelId == id);
        }

        public async Task<Model> CreateModel(Model model)
        {
            await _context.AddAsync(model);
            await _context.SaveChangesAsync();
            return model;
        }

        public async Task<Model> UpdateModel(int id, Model model)
        {
            var data = await _context.Models.FindAsync(id);
            if (data == null)
            {
                return null;
            }

            _context.Models.Update(model);
            await _context.SaveChangesAsync();

            return model;
        }

        public async Task DeleteModel(int id)
        {
            var model = await _context.Models.FindAsync(id);
            if (model != null)
            {
                _context.Models.Remove(model);
                await _context.SaveChangesAsync();
            }
        }
    }
}