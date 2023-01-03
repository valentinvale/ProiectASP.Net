using ProiectASPNET.Models;
using ProiectASPNET.Repositories.GenericRepository;

namespace ProiectASPNET.Repositories.BookRepository
{
    public interface IBookRepository : IGenericRepository<Book>
    {
        //IEnumerable<Book> GetBooksByAuthor(string author);
        //IEnumerable<Book> GetBooksByTitle(string title);
        //IEnumerable<Book> GetBooksByGenre(string genre);
        //IEnumerable<Book> GetBooksByYearPublished(int year);
        //IEnumerable<Book> GetBooksByPublisher(string publisher);
        //IEnumerable<Book> GetBooksByISBN(string isbn);

    }
    
}
