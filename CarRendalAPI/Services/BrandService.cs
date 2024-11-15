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

        public async Task<IEnumerable<Brand>> GetAllBrands()
        {
            return await _brandRepository.GetAllBrands();
        }

        public async Task<Brand> GetBrandById(int id)
        {
            var brand = await _brandRepository.GetBrandById(id);
            if (brand == null) throw new KeyNotFoundException("Brand not found.");

            return brand;
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

        public async Task<BrandResDTO> UpdateBrand(int id, BrandReqDTO brandReqDTO)
        {
            if (id != brandReqDTO.BrandId)
            {
                throw new ArgumentException("The ID in the URL does not match the ID in the body.");
            }
            var existingCarBrand = await _brandRepository.GetBrandById(id);
            if (existingCarBrand == null)
            {
                throw new KeyNotFoundException("Brand not found.");
            }

            existingCarBrand.BrandId = id;
            existingCarBrand.Name = brandReqDTO.Name;
            existingCarBrand.Country = brandReqDTO.Country;
            existingCarBrand.FoundedYear = brandReqDTO.FoundedYear;
            existingCarBrand.LogoUrl = brandReqDTO.LogoUrl;
            existingCarBrand.Website = brandReqDTO.Website;
            existingCarBrand.Description = brandReqDTO.Description;

            var data = await _brandRepository.UpdateBrand(existingCarBrand);

            var responce = new BrandResDTO
            {
                BrandId = data.BrandId,
                Name = data.Name,
                Country = data.Country,
                FoundedYear = data.FoundedYear,
                LogoUrl = data.LogoUrl,
                Website = data.Website,
                Description = data.Description
            };
            return responce;
        }

        public async Task<bool> DeleteBrand(int id)
        {
            var success =  await _brandRepository.DeleteBrand(id);
            if (!success) throw new KeyNotFoundException("Brand not found.");
            return success;
        }
    }
}
