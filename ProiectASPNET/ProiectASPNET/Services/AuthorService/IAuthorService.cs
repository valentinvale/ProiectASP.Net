using ProiectASPNET.Models;
using ProiectASPNET.Models.DTOs;

namespace ProiectASPNET.Services.AuthorService
{
    public interface IAuthorService
    {
        Task<List<AuthorDTO>> GetAllAuthors();
        public Task<List<AuthorDTO>> GetAuthorsById(Guid authorId);
        Task<List<AuthorDTO>> GetAuthorsByName(string authorName);
        Task<List<AuthorDTO>> CreateAuthorAsync(CreateAuthorDTO author);

        Task<List<AuthorDTO>> GetAuthorsByBookId(Guid bookId);

        Task<List<AuthorDTO>> GetAuthorsByBookName(string bookName);

        Task UpdateAuthorAsync(UpdateAuthorDTO author);
        Task DeleteAuthor(Guid authorId);
    }
}
