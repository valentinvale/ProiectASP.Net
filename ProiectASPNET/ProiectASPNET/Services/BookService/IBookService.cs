using ProiectASPNET.Models.DTOs;

namespace ProiectASPNET.Services.BookService
{
    public interface IBookService
    {
        Task<List<BookDTO>> GetAllBooks();
        Task<List<BookDTO>> CreateBookAsync(CreateBookDTO book);
    }
}
