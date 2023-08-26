using ProiectASPNET.Models;
using ProiectASPNET.Repositories.GenericRepository;

namespace ProiectASPNET.Repositories.ReviewRepository
{
    public interface IReviewRepository : IGenericRepository<Review>
    {
        public Task<Review> GetReviewByUserAndBookId(Guid userId, Guid bookId);
    }

    



}
