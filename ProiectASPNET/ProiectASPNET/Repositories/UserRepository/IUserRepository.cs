using ProiectASPNET.Models;
using ProiectASPNET.Repositories.GenericRepository;

namespace ProiectASPNET.Repositories.UserRepository
{
    public interface IUserRepository : IGenericRepository<User>
    {
        User FindByUsername(string username);
    }
}
