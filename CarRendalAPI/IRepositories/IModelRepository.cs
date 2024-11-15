using CarRendalAPI.Models;

namespace CarRendalAPI.IRepositories
{
    public interface IModelRepository
    {
        Task<IEnumerable<Model>> GetAllModels();
        Task<Model> GetModelById(int id);
        Task<Model> CreateModel(Model model);
        Task<Model> UpdateModel(Model model);
        Task<bool> DeleteModel(int id);
        Task<bool> BrandExistsAsync(int brandId);
    }
}
