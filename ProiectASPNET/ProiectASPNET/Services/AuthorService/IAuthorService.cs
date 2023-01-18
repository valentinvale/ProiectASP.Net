using ProiectASPNET.Models;
using ProiectASPNET.Models.DTOs;

namespace ProiectASPNET.Services.AuthorService
{
    public interface IAuthorService
    {
        Task<List<AuthorDTO>> GetAllAuthors();
        Task<List<AuthorDTO>> CreateAuthorAsync(CreateAuthorDTO author);

        Task UpdateAuthorAsync(UpdateAuthorDTO author);
        Task DeleteAuthor(Guid authorId);
    }
}
