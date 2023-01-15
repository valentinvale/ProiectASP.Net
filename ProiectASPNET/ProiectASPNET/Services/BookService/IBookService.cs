using ProiectASPNET.Models;
using ProiectASPNET.Models.DTOs;

namespace ProiectASPNET.Services.BookService
{
    public interface IBookService
    {
        Task<List<BookDTO>> GetAllBooks();
        public Task<List<BookDTO>> GetAllBooksWithAuthors();
        Task<List<BookDTO>> CreateBookAsync(CreateBookDTO book);
        public Task<List<AuthorInBookDTO>> AddAuthorsToBook(Guid bookId, List<Guid> authorIds);
    }
}
