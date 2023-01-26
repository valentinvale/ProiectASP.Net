using ProiectASPNET.Models;
using ProiectASPNET.Repositories.GenericRepository;

namespace ProiectASPNET.Repositories.BookRepository
{
    public interface IBookRepository : IGenericRepository<Book>
    {
        public Task<List<Book>> GetBooksWithReviewsAsync();
        public Task<List<Book>> GetAuthorsWithBooksAsync();

        public Task<List<Book>> GetAllWithBooksAsync();

        public Task<List<Book>> GetBooksByAuthorId(Guid authorId);
        public Task<List<Book>> GetBooksByAuthorName(string authorName);

        public Task<List<Book>> GetBooksByGenre(string bookGenre);

        public Task<List<Book>> GetBooksByISBN(string isbn);

        public Task<List<Book>> GetBooksById(Guid bookId);

        public Task<List<Book>> GetBooksByTitle(string bookTitle);

        Task<Book> GetBookByQuoteId(Guid quoteId);
    }






}
