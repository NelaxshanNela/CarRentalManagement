using CarRendalAPI.DTOs.RequestDTOs;
using CarRendalAPI.DTOs.ResponceDTOs;
using CarRendalAPI.Models;

namespace CarRendalAPI.IServices
{
    public interface IModelService
    {
        Task<string> CreateModel(ModelReqDTO modelReqDTO);
        Task<List<Model>> GetAllModels();
        Task<Model> GetModelById(int id);
        Task<string> UpdateModel(int id, ModelReqDTO modelReqDTO);
        Task<bool> DeleteModel(int id);
    }
}
