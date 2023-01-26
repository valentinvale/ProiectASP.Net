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

        public async Task<List<AuthorDTO>> GetAuthorsById(Guid authorId)
        {
            var authors = await _authorRepository.GetAuthorsById(authorId);
            var authorsDTO = _mapper.Map<List<AuthorDTO>>(authors);
            return authorsDTO;
        }

        public async Task<List<AuthorDTO>> GetAuthorsByName(string authorName)
        {
            var authors = await _authorRepository.GetAuthorsByName(authorName);
            var authorsDTO = _mapper.Map<List<AuthorDTO>>(authors);
            return authorsDTO;
        }

        public async Task<List<AuthorDTO>> GetAuthorsByBookId(Guid bookId)
        {
            var authors = await _authorRepository.GetAuthorsByBookId(bookId);
            var authorsDTO = _mapper.Map<List<AuthorDTO>>(authors);
            return authorsDTO;
        }

        public async Task<List<AuthorDTO>> GetAuthorsByBookName(string bookName)
        {
            var authors = await _authorRepository.GetAuthorsByBookName(bookName);
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

        public async Task UpdateAuthorAsync(UpdateAuthorDTO author)
        {
            _authorRepository.Update(_mapper.Map<Author>(author));
            await _authorRepository.SaveAsync();
        }

        public async Task DeleteAuthor(Guid authorId)
        {
            var author = await _authorRepository.FindByIdAsync(authorId);
            _authorRepository.Delete(author);
            await _authorRepository.SaveAsync();
        }

    }

}
