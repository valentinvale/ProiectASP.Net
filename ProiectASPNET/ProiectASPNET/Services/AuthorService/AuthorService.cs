using AutoMapper;
using ProiectASPNET.Models;
using ProiectASPNET.Models.DTOs;
using ProiectASPNET.Repositories.AuthorRepository;
namespace ProiectASPNET.Services.AuthorService
{
    public class AuthorService : IAuthorService
    {
        public readonly IAuthorRepository _authorRepository;
        public readonly IMapper _mapper;

        public AuthorService(IAuthorRepository authorRepository, IMapper mapper)
        {
            _authorRepository = authorRepository;
            _mapper = mapper;
        }

        public async Task<List<AuthorDTO>> GetAllAuthors()
        {
            var authors = await _authorRepository.GetAllAsync();
            var authorsDTO = _mapper.Map<List<AuthorDTO>>(authors);
            return authorsDTO;
        }

        public async Task<List<AuthorDTO>> CreateAuthorAsync(CreateAuthorDTO author)
        {
            var authorEntity = _mapper.Map<Author>(author);
            await _authorRepository.CreateAsync(authorEntity);
            await _authorRepository.SaveAsync();
            var authors = await _authorRepository.GetAllAsync();
            var authorsDTO = _mapper.Map<List<AuthorDTO>>(authors);
            return authorsDTO;
        }


    }

}
