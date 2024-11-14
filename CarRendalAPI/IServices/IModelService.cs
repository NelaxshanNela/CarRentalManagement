using CarRendalAPI.DTOs.RequestDTOs;
using CarRendalAPI.DTOs.ResponceDTOs;
using CarRendalAPI.Models;

namespace CarRendalAPI.IServices
{
    public interface IModelService
    {
        Task<ModelResDTO> CreateModel(ModelReqDTO modelReqDTO);
        Task<IEnumerable<Model>> GetAllModels();
        Task<Model> GetModelById(int id);
        Task<ModelResDTO> UpdateModel(int id, ModelReqDTO modelReqDTO);
        Task DeleteModel(int id);
    }
}
