﻿using Microsoft.AspNetCore.Http;
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

        [HttpGet("{reviewId}")]
        public async Task<IActionResult> GetReviewById([FromRoute] Guid reviewId)
        {
            var review = await _reviewService.GetReviewById(reviewId);
            return Ok(review);
        }

        [HttpGet("{userId}/{bookId}")]
        public async Task<IActionResult> GetReviewByUserAndBookId([FromRoute] Guid userId, [FromRoute] Guid bookId)
        {
            var review = await _reviewService.GetReviewByUserAndBookId(userId, bookId);
            return Ok(review);
        }

        [HttpPost]

        public async Task<IActionResult> PostReview([FromBody] CreateReviewDTO review)
        {
            Console.WriteLine(review);
            var newReviews = await _reviewService.CreateReviewAsync(review);
            return Ok(newReviews);
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
