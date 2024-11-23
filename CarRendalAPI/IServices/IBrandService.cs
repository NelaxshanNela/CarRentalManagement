using CarRendalAPI.DTOs.RequestDTOs;
using CarRendalAPI.DTOs.ResponceDTOs;
using CarRendalAPI.Models;

namespace CarRendalAPI.IServices
{
    public interface IBrandService
    {
        Task<List<Brand>> GetAllBrands();
        Task<Brand> GetBrandById(int id);
        Task<string> CreateBrand(BrandReqDTO brandReqDTO);
        Task<string> UpdateBrand(int id, BrandReqDTO brandReqDTO);
        Task<bool> DeleteBrand(int id);
    }
}
