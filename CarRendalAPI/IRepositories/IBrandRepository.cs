using CarRendalAPI.Models;

namespace CarRendalAPI.IRepositories
{
    public interface IBrandRepository
    {
        Task<IEnumerable<Brand>> GetAllBrands();
        Task<Brand> GetBrandById(int id);
        Task<Brand> CreateBrand(Brand brand);
        Task<Brand> UpdateBrand(int id, Brand brand);
        Task DeleteBrand(int id);
    }
}
