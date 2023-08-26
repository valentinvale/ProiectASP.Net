using Microsoft.EntityFrameworkCore;
using ProiectASPNET.Data;
using ProiectASPNET.Models;
using ProiectASPNET.Repositories.GenericRepository;

namespace ProiectASPNET.Repositories.ReviewRepository
{
    public class ReviewRepository : GenericRepository<Review>, IReviewRepository
    {
        public ReviewRepository(ProjectContext context) : base(context)
        {
        }

        public async Task<Review> GetReviewByUserAndBookId(Guid userId, Guid bookId)
        {
            return await _context.Reviews
                .Include(r => r.Book)
                .FirstOrDefaultAsync(r => r.UserId == userId && r.BookId == bookId);
        }

    }
   
}
