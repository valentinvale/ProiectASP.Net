using ProiectASPNET.Models;
using ProiectASPNET.Repositories.GenericRepository;

namespace ProiectASPNET.Repositories.AuthorRepository
{
    public interface IAuthorRepository : IGenericRepository<Author>
    {
        public Task<List<Author>> FindRangeAsync(List<Guid> authorIds);
        public Task<List<Author>> GetAuthorsById(Guid authorId);
        public Task<List<Author>> GetAuthorsByName(string authorName);

        public Task<List<Author>> GetAuthorsByBookId(Guid bookId);

        public Task<List<Author>> GetAuthorsByBookName(string bookName);
    }

    
    
    
}
