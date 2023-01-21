using ProiectASPNET.Data;
using ProiectASPNET.Models;
using ProiectASPNET.Repositories.GenericRepository;

namespace ProiectASPNET.Repositories.AuthorInBookRepository
{
    public class AuthorInBookRepository : GenericRepository<AuthorInBook>, IAuthorInBookRepository
    {
        public AuthorInBookRepository(ProjectContext context) : base(context)
        {
        }

    }
}
