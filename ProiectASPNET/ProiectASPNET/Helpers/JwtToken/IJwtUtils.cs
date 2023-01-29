using ProiectASPNET.Models;

namespace ProiectASPNET.Helpers.JwtToken
{
    public interface IJwtUtils
    {
        public string GenerateJwtToken(User user);
        public Guid ValidateJwtToken(string token);
    }
}
