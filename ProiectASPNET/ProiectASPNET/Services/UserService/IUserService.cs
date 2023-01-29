using ProiectASPNET.Models;
using ProiectASPNET.Models.DTOs;

namespace ProiectASPNET.Services.UserService
{
    public interface IUserService
    {
        UserResponseDTO Authenticate(UserRequestDTO model);
        User GetById(Guid id);
        Task<List<User>> GetAllUsers();
        Task Create(User newUser);
    }
}
