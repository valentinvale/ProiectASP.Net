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
            await _reviewService.CreateReviewAsync(review);
            return Ok(review);
        }


    }
}
