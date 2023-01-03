using ProiectASPNET.Models.DTOs;

namespace ProiectASPNET.Services.AuthorService
{
    public interface IAuthorService
    {
        Task<List<AuthorDTO>> GetAllAuthors();
    }
}
