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

        public async Task<List<Brand>> GetAllBrands()
        {
            var brands = await _brandRepository.GetAllBrands();
            if (brands == null) throw new KeyNotFoundException("No Brands available.");
            return brands;
        }

        public async Task<Brand> GetBrandById(int id)
        {
            var brand = await _brandRepository.GetBrandById(id);
            if (brand == null) throw new KeyNotFoundException("Brand not found.");

            return brand;
        }

        public async Task<string> CreateBrand(BrandReqDTO brandReqDTO)
        {
            var existingBrand = await _brandRepository.GetBrandByName(brandReqDTO.Name);
            if (existingBrand != null)
            {
                throw new ArgumentException("This Brand is already registered.");
            }

            var brand = new Brand
            {
                Name = brandReqDTO.Name,
                Country = brandReqDTO.Country,
                FoundedYear = brandReqDTO.FoundedYear,
                LogoUrl = brandReqDTO.LogoUrl,
                Website = brandReqDTO.Website,
                Description = brandReqDTO.Description
            };
            await _brandRepository.CreateBrand(brand);
            return "Brand Created Succesfully";
        }

        public async Task<string> UpdateBrand(int id, BrandReqDTO brandReqDTO)
        {
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

            await _brandRepository.UpdateBrand(existingCarBrand);
            return "Brand Updated Successfully";
        }

        public async Task<bool> DeleteBrand(int id)
        {
            var success = await _brandRepository.DeleteBrand(id);
            if (!success) throw new KeyNotFoundException("Brand not found.");
            return success;
        }
    }
}
