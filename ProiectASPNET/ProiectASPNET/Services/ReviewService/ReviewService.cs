﻿using AutoMapper;
using ProiectASPNET.Models.DTOs;
using ProiectASPNET.Repositories.ReviewRepository;

namespace ProiectASPNET.Services.ReviewService
{
    public class ReviewService : IReviewService
    {
        public readonly IReviewRepository _reviewRepository;
        public readonly IMapper _mapper;

        public ReviewService(IReviewRepository reviewRepository, IMapper mapper)
        {
            _reviewRepository = reviewRepository;
            _mapper = mapper;
        }

        public async Task<List<ReviewDTO>> GetAllReviews()
        {
            var reviews = await _reviewRepository.GetAllAsync();
            var reviewsDTO = _mapper.Map<List<ReviewDTO>>(reviews);
            return reviewsDTO;
        }

 
    }

}
