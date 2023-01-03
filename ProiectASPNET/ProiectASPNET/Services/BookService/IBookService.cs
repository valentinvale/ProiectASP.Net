using ProiectASPNET.Models.DTOs;

namespace ProiectASPNET.Services.BookService
{
    public interface IBookService
    {
        Task<List<BookDTO>> GetAllBooks();
    }
}
