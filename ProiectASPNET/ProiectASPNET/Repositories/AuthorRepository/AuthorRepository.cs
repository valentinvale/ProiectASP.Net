using Microsoft.EntityFrameworkCore;
using ProiectASPNET.Data;
using ProiectASPNET.Models;
using ProiectASPNET.Repositories.GenericRepository;

namespace ProiectASPNET.Repositories.AuthorRepository
{
    public class AuthorRepository : GenericRepository<Author>, IAuthorRepository
    {
        public AuthorRepository(ProjectContext context) : base(context)
        {
        }

        public async Task<List<Author>> FindRangeAsync(List<Guid> authorIds)
        {
            return await _table.Where(x => authorIds.Contains(x.Id)).ToListAsync();
        }
    }
    
}
