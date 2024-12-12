using CarRendalAPI.DTOs.RequestDTOs;
using CarRendalAPI.IRepositories;
using CarRendalAPI.IServices;
using CarRendalAPI.Models;

namespace CarRendalAPI.Services
{
    public class ReviewService : IReviewService
    {
        private readonly IReviewRepository _reviewRepository;

        public ReviewService(IReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }

        public async Task<Review> AddReviewAsync(ReviewReqDTO reviewReqDTO)
        {
            var review = new Review
            {
                Rating = reviewReqDTO.Rating,
                Comments = reviewReqDTO.Comments,
                UserId = reviewReqDTO.UserId,
                CarId = reviewReqDTO.CarId
            };
            return await _reviewRepository.AddReviewAsync(review);
        }

        public async Task<IEnumerable<Review>> GetAllReviewsAsync()
        {
            return await _reviewRepository.GetAllReviewsAsync();
        }

        public async Task<Review> GetReviewByIdAsync(int id)
        {
            return await _reviewRepository.GetReviewByIdAsync(id);
        }

        public async Task<bool> DeleteReviewAsync(int id)
        {
            return await _reviewRepository.DeleteReviewAsync(id);
        }

        public async Task<Review> UpdateReviewAsync(int id, ReviewReqDTO reviewReqDTO)
        {
            var review = await _reviewRepository.GetReviewByIdAsync(id);
            if (review == null) return null;

            review.Rating = reviewReqDTO.Rating;
            review.Comments = reviewReqDTO.Comments;
            review.UpdatedAt = DateTime.UtcNow;

            return await _reviewRepository.UpdateReviewAsync(review);
        }
    }
}
