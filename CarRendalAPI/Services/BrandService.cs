using CarRendalAPI.DTOs.RequestDTOs;
using CarRendalAPI.DTOs.ResponceDTOs;
using CarRendalAPI.IRepositories;
using CarRendalAPI.IServices;
using CarRendalAPI.Models;
using CarRendalAPI.Repositories;

namespace CarRendalAPI.Services
{
    public class BrandService : IBrandService
    {
        private readonly IBrandRepository _brandRepository;

        public BrandService(IBrandRepository brandRepository)
        {
            _brandRepository = brandRepository;
        }

        public async Task<BrandResDTO> CreateBrand(BrandReqDTO brandReqDTO)
        {
            var brand = new Brand
            {
                Name = brandReqDTO.Name,
                Country = brandReqDTO.Country,
                FoundedYear = brandReqDTO.FoundedYear,
                LogoUrl = brandReqDTO.LogoUrl,
                Website = brandReqDTO.Website,
                Description = brandReqDTO.Description
            };
            var data = await _brandRepository.CreateBrand(brand);

            var responce = new BrandResDTO
            {
                BrandId = data.BrandId,
                Name = data.Name,
                Country = data.Country,
                FoundedYear = data.FoundedYear,
                LogoUrl = data.LogoUrl,
                Website = data.Website,
                Description = data.Description,
                Models = data.Models
            };
            return responce;
        }

        public async Task<IEnumerable<Brand>> GetAllBrands()
        {
            return await _brandRepository.GetAllBrands();
        }

        public async Task<Brand> GetBrandById(int id)
        {
            return await _brandRepository.GetBrandById(id);
        }

        public async Task<BrandResDTO> UpdateBrand(int id, BrandReqDTO brandReqDTO)
        {
            var brand = new Brand
            {
                BrandId = id,
                Name = brandReqDTO.Name,
                Country = brandReqDTO.Country,
                FoundedYear = brandReqDTO.FoundedYear,
                LogoUrl = brandReqDTO.LogoUrl,
                Website = brandReqDTO.Website,
                Description = brandReqDTO.Description
            };

            var data = await _brandRepository.UpdateBrand(id, brand);

            var responce = new BrandResDTO
            {
                BrandId = id,
                Name = brandReqDTO.Name,
                Country = brandReqDTO.Country,
                FoundedYear = brandReqDTO.FoundedYear,
                LogoUrl = brandReqDTO.LogoUrl,
                Website = brandReqDTO.Website,
                Description = brandReqDTO.Description
            };
            return responce;
        }

        public async Task DeleteBrand(int id)
        {
            await _brandRepository.DeleteBrand(id);
        }
    }
}
