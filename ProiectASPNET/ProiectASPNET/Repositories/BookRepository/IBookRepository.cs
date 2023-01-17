using ProiectASPNET.Models;
using ProiectASPNET.Repositories.GenericRepository;

namespace ProiectASPNET.Repositories.BookRepository
{
    public interface IBookRepository : IGenericRepository<Book>
    {
        public Task<List<Book>> GetBooksWithReviewsAsync();
        public Task<List<Book>> GetAuthorsWithBooksAsync();

        public Task<List<Book>> GetAuthorsAndReviewsWithBooksAsync();
    }

    
    
        
    

}
