using ProiectASPNET.Models;
using ProiectASPNET.Models.DTOs;

namespace ProiectASPNET.Services.BookService
{
    public interface IBookService
    {
        Task<List<AuthorAndReviewInBook>> GetAllBooks();
        public Task<List<AuthorInBookDTO>> GetAllBooksWithAuthors();
        public Task<List<BookDTO>> GetAllBooksWithReviews();
        public Task<List<AuthorAndReviewInBook>> GetBooksByAuthorId(Guid authorId);
        Task<List<BookDTO>> CreateBookAsync(CreateBookDTO book);
        public Task<List<AuthorInBookDTO>> AddAuthorsToBook(Guid bookId, List<Guid> authorIds);

        Task UpdateBookAsync(UpdateBookDTO book);

        Task DeleteBook(Guid bookId);
    }
}
