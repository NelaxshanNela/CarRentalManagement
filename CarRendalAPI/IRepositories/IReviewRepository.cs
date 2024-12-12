using CarRendalAPI.Models;

namespace CarRendalAPI.IRepositories
{
    public interface IReviewRepository
    {
        Task<Review> AddReviewAsync(Review review);
        Task<IEnumerable<Review>> GetAllReviewsAsync();
        Task<Review> GetReviewByIdAsync(int id);
        Task<bool> DeleteReviewAsync(int id);
        Task<Review> UpdateReviewAsync(Review review);
    }
}