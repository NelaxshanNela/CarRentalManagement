using CarRendalAPI.DTOs.RequestDTOs;
using CarRendalAPI.DTOs.ResponceDTOs;
using CarRendalAPI.Models;

namespace CarRendalAPI.IServices
{
    public interface IBrandService
    {
        Task<IEnumerable<Brand>> GetAllBrands();
        Task<Brand> GetBrandById(int id);
        Task<Brand> CreateBrand(BrandReqDTO brandReqDTO);
        Task<Brand> UpdateBrand(int id, BrandReqDTO brandReqDTO);
        Task<bool> DeleteBrand(int id);
    }
}
