using ProiectASPNET.Models.DTOs;

namespace ProiectASPNET.Services
{
    public interface IAuthorService
    {
        Task<List<AuthorDTO>> GetAllAuthors();
    }
}
