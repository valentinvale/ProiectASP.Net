using Microsoft.EntityFrameworkCore;
using ProiectASPNET.Data;
using ProiectASPNET.Models;
using ProiectASPNET.Repositories.GenericRepository;

namespace ProiectASPNET.Repositories.BookRepository
{
    public class BookRepository : GenericRepository<Book>, IBookRepository
    {
        public BookRepository(ProjectContext context) : base(context)
        {
        }

        public async Task<List<Book>> GetBooksWithReviewsAsync()
        {
            return await _table.Include(x => x.Reviews).ToListAsync();
        }
        
        public async Task<List<Book>> GetAuthorsWithBooksAsync()
        {
            return await _table.Include(x => x.AuthorsLink).ThenInclude(x => x.Author).ToListAsync();
        }
    }

}
