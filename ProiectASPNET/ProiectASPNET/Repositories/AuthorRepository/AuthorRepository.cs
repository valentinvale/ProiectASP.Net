using Microsoft.EntityFrameworkCore;
using ProiectASPNET.Data;
using ProiectASPNET.Models;
using ProiectASPNET.Repositories.GenericRepository;

namespace ProiectASPNET.Repositories.AuthorRepository
{
    public class AuthorRepository : GenericRepository<Author>, IAuthorRepository
    {
        public AuthorRepository(ProjectContext context) : base(context)
        {
        }

        public async Task<List<Author>> FindRangeAsync(List<Guid> authorIds)
        {
            return await _table.Where(x => authorIds.Contains(x.Id)).ToListAsync();
        }

        public async Task<List<Author>> GetAuthorsById(Guid authorId)
        {
            return await _table.Where(x => x.Id == authorId).ToListAsync();
        }

        public async Task<List<Author>> GetAuthorsByName(string authorName)
        {
            return await _table.Where(x => x.FirstName.Contains(authorName) || x.LastName.Contains(authorName)).ToListAsync();
        }

        public async Task<List<Author>> GetAuthorsByBookId(Guid bookId)
        {
            return await _table.Include(x => x.BooksLink).ThenInclude(y => y.Book)
                .Where(x => x.BooksLink.Any(y => y.BookId == bookId)).ToListAsync();
        }

        public async Task<List<Author>> GetAuthorsByBookName(string bookName)
        {
            return await _table.Include(x => x.BooksLink).ThenInclude(y => y.Book)
                .Where(x => x.BooksLink.Any(y => y.Book.Title.Contains(bookName))).ToListAsync();
        }

    }
    
}
