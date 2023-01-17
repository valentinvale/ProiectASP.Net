using ProiectASPNET.Models;
using ProiectASPNET.Repositories.GenericRepository;

namespace ProiectASPNET.Repositories.AuthorRepository
{
    public interface IAuthorRepository : IGenericRepository<Author>
    {
        public Task<List<Author>> FindRangeAsync(List<Guid> authorIds);
    }

    
    
    
}
