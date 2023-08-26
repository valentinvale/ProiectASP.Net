using AutoMapper;
using ProiectASPNET.Models;
using ProiectASPNET.Models.DTOs;
using ProiectASPNET.Repositories.BookRepository;
using ProiectASPNET.Repositories.ReviewRepository;

namespace ProiectASPNET.Services.ReviewService
{
    public class ReviewService : IReviewService
    {
        public readonly IReviewRepository _reviewRepository;
        public readonly IBookRepository _bookRepository;
        public readonly IMapper _mapper;

        public ReviewService(IReviewRepository reviewRepository, IBookRepository bookRepository, IMapper mapper)
        {
            _reviewRepository = reviewRepository;
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public async Task<List<ReviewDTO>> GetAllReviews()
        {
            var reviews = await _reviewRepository.GetAllAsync();
            var reviewsDTO = _mapper.Map<List<ReviewDTO>>(reviews);
            return reviewsDTO;
        }

        public async Task<ReviewDTO> GetReviewById(Guid reviewId)
        {
            var review = await _reviewRepository.FindByIdAsync(reviewId);
            var reviewDTO = _mapper.Map<ReviewDTO>(review);
            return reviewDTO;
        }

        public async Task<ReviewDTO> GetReviewByUserAndBookId(Guid userId, Guid bookId)
        {
            var review = await _reviewRepository.GetReviewByUserAndBookId(userId, bookId);
            var reviewDTO = _mapper.Map<ReviewDTO>(review);
            return reviewDTO;
        }

        public async Task<List<ReviewDTO>> CreateReviewAsync(CreateReviewDTO review)
        {
            var reviewEntity = _mapper.Map<Review>(review);
            await _reviewRepository.CreateAsync(reviewEntity);
            await _reviewRepository.SaveAsync();
            var reviews = await _reviewRepository.GetAllAsync();
            var reviewsDTO = _mapper.Map<List<ReviewDTO>>(reviews);
            return reviewsDTO;
        }

        public async Task UpdateReviewAsync(Guid bookId, UpdateReviewDTO review)
        {
            var r = _mapper.Map<Review>(review);
            r.Book = _bookRepository.FindByIdAsync(bookId).Result; // trebuie facut asta ca altfel da eroare
            _reviewRepository.Update(r);
            await _reviewRepository.SaveAsync();
        }

        public async Task DeleteReview(Guid reviewId)
        {
            var review = await _reviewRepository.FindByIdAsync(reviewId);
            _reviewRepository.Delete(review);
            await _reviewRepository.SaveAsync();

        }    


    }

}
