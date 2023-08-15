using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProiectASPNET.Models.DTOs;
using ProiectASPNET.Repositories.ReviewRepository;
using ProiectASPNET.Services.ReviewService;

namespace ProiectASPNET.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        public readonly IReviewService _reviewService;

        public ReviewController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        [HttpGet]
        public async Task<IActionResult> GetReviews()
        {
            var reviews = await _reviewService.GetAllReviews();
            return Ok(reviews);
        }

        [HttpPost]

        public async Task<IActionResult> PostReview([FromBody] CreateReviewDTO review)
        {
            Console.WriteLine(review);
            await _reviewService.CreateReviewAsync(review);
            return Ok(review);
        }

        [HttpPost("update/{bookId}")]
        public async Task<IActionResult> UpdateReview([FromRoute] Guid bookId, [FromBody] UpdateReviewDTO review)
        {
            await _reviewService.UpdateReviewAsync(bookId, review);
            return Ok(review);
        }

        [HttpDelete("{reviewId}")]
        public async Task<IActionResult> DeleteReview([FromRoute] Guid reviewId)
        {
            await this._reviewService.DeleteReview(reviewId);
            return Ok(await _reviewService.GetAllReviews());
        }


    }
}
