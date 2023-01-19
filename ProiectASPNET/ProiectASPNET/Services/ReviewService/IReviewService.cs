using ProiectASPNET.Models.DTOs;

namespace ProiectASPNET.Services.ReviewService
{
    public interface IReviewService
    {
        Task<List<ReviewDTO>> GetAllReviews();
        Task<List<ReviewDTO>> CreateReviewAsync(CreateReviewDTO review);
        Task UpdateReviewAsync(Guid bookId, UpdateReviewDTO review);

        Task DeleteReview(Guid reviewId);
    }
}
