using CarRendalAPI.Models;

namespace CarRendalAPI.IRepositories
{
    public interface IBrandRepository
    {
        Task<List<Brand>> GetAllBrands();
        Task<Brand> GetBrandById(int id);
        Task<Brand> GetBrandByName(string name);
        Task<Brand> CreateBrand(Brand brand);
        Task<Brand> UpdateBrand(Brand brand);
        Task<bool> DeleteBrand(int id);
    }
}
