using ProiectASPNET.Helpers.JwtUtils;
using ProiectASPNET.Models;
using ProiectASPNET.Models.DTOs;
using ProiectASPNET.Repositories.UserRepository;
using BCryptNet = BCrypt.Net.BCrypt;
namespace ProiectASPNET.Services.UserService
{
    public class UserService : IUserService
    {
        public IUserRepository _userRepository;
        public IJwtUtils _jwtUtils;

        public UserService(IUserRepository userRepository, IJwtUtils jwtUtils)
        {
            _userRepository = userRepository;
            _jwtUtils = jwtUtils;
        }

        public UserResponseDTO Authenticate(UserLoginDTO model)
        {
            var user = _userRepository.FindByUsername(model.UserName);
            if (user == null || !BCryptNet.Verify(model.Password, user.PasswordHash))
            {
                return null;
            }

            var jwtToken = _jwtUtils.GenerateJwtToken(user);
            return new UserResponseDTO(user, jwtToken);
        }

        public async Task Create(User newUser)
        {
            await _userRepository.CreateAsync(newUser);
            await _userRepository.SaveAsync();
        }

        public async Task<List<User>> GetAllUsers()
        {
            return await _userRepository.GetAllAsync();
        }

        public User GetById(Guid id)
        {
            return _userRepository.FindById(id);
        }
    }
}
