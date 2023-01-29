using ProiectASPNET.Data;
using ProiectASPNET.Models;
using ProiectASPNET.Repositories.GenericRepository;

namespace ProiectASPNET.Repositories.UserRepository
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(ProjectContext context) : base(context)
        {

        }

        public User FindByUsername(string username)
        {
            return _table.FirstOrDefault(x => x.UserName == username);
        }

    }
}
