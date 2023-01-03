using ProiectASPNET.Models.DTOs;

namespace ProiectASPNET.Services.ReviewService
{
    public interface IReviewService
    {
        Task<List<ReviewDTO>> GetAllReviews();
    }
}
