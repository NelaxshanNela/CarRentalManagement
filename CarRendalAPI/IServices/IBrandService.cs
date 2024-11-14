using CarRendalAPI.DTOs.RequestDTOs;
using CarRendalAPI.DTOs.ResponceDTOs;
using CarRendalAPI.Models;

namespace CarRendalAPI.IServices
{
    public interface IBrandService
    {
        Task<IEnumerable<Brand>> GetAllBrands();
        Task<Brand> GetBrandById(int id);
        Task<BrandResDTO> CreateBrand(BrandReqDTO brandReqDTO);
        Task<BrandResDTO> UpdateBrand(int id, BrandReqDTO brandReqDTO);
        Task DeleteBrand(int id);
    }
}
