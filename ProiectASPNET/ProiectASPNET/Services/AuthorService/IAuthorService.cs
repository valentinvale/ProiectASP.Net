using ProiectASPNET.Models.DTOs;

namespace ProiectASPNET.Services.AuthorService
{
    public interface IAuthorService
    {
        Task<List<AuthorDTO>> GetAllAuthors();
        Task<List<AuthorDTO>> CreateAuthorAsync(CreateAuthorDTO author);
    }
}
