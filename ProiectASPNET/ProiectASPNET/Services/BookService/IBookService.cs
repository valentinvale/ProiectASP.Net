using ProiectASPNET.Models;
using ProiectASPNET.Models.DTOs;

namespace ProiectASPNET.Services.BookService
{
    public interface IBookService
    {
        public Task<List<BookDTO>> GetAllBooksWithReviews();
        public Task<List<AuthorInBookDTO>> GetAllBooksWithAuthors();

        public Task<List<AuthorAndReviewInBook>> GetAllBooks();
        public Task<List<BookDTO>> CreateBookAsync(CreateBookDTO book);
        public Task<List<AuthorInBookDTO>> AddAuthorsToBook(Guid bookId, List<Guid> authorIds);
    }
}
