using CarRendalAPI.DTOs.RequestDTOs;
using CarRendalAPI.Models;

namespace CarRendalAPI.IServices
{
    public interface IReviewService
    {
        Task<Review> AddReviewAsync(ReviewReqDTO reviewReqDTO);
        Task<IEnumerable<Review>> GetAllReviewsAsync();
        Task<Review> GetReviewByIdAsync(int id);
        Task<bool> DeleteReviewAsync(int id);
        Task<Review> UpdateReviewAsync(int id, ReviewReqDTO reviewReqDTO);
    }
}