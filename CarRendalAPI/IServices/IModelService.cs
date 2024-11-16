using CarRendalAPI.DTOs.RequestDTOs;
using CarRendalAPI.DTOs.ResponceDTOs;
using CarRendalAPI.Models;

namespace CarRendalAPI.IServices
{
    public interface IModelService
    {
        Task<Model> CreateModel(ModelReqDTO modelReqDTO);
        Task<IEnumerable<Model>> GetAllModels();
        Task<Model> GetModelById(int id);
        Task<Model> UpdateModel(int id, ModelReqDTO modelReqDTO);
        Task<bool> DeleteModel(int id);
    }
}
