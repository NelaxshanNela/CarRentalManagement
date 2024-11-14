using CarRendalAPI.Models;

namespace CarRendalAPI.IRepositories
{
    public interface IModelRepository
    {
        Task<IEnumerable<Model>> GetAllModels();
        Task<Model> GetModelById(int id);
        Task<Model> CreateModel(Model model);
        Task<Model> UpdateModel(int id, Model model);
        Task DeleteModel(int id);
    }
}
