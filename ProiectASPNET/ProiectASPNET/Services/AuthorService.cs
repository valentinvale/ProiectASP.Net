using ProiectASPNET.Models.DTOs;
using ProiectASPNET.Repositories.AuthorRepository;

namespace ProiectASPNET.Services
{
    public class AuthorService : IAuthorService
    {
        public IAuthorRepository _authorRepository;

        public AuthorService(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public Task<List<AuthorDTO>> GetAllAuthors()
        {
            //Mapper
            return _authorRepository.GetAllAsync();
        }
            
    }
   
}
