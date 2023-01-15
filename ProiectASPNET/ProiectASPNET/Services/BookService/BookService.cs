using AutoMapper;
using ProiectASPNET.Models;
using ProiectASPNET.Models.DTOs;
using ProiectASPNET.Repositories.AuthorInBookRepository;
using ProiectASPNET.Repositories.AuthorRepository;
using ProiectASPNET.Repositories.BookRepository;

namespace ProiectASPNET.Services.BookService
{
    public class BookService : IBookService
    {
        public readonly IBookRepository _bookRepository;
        public readonly IAuthorRepository _authorRepository;
        private readonly IAuthorInBookRepository _authorInBookRepository;
        public readonly IMapper _mapper;
        private object authorInBookRepository;

        public BookService(IBookRepository bookRepository, IMapper mapper, IAuthorInBookRepository authorInBookRepository, IAuthorRepository authorRepository)
        {
            _bookRepository = bookRepository;
            _authorRepository = authorRepository;
            _authorInBookRepository = authorInBookRepository;
            _mapper = mapper;
        }

        public async Task<List<BookDTO>> GetAllBooks()
        {
            var books = await _bookRepository.GetBooksWithReviewsAsync();
            //var books = await _bookRepository.GetAllAsync();
            var booksDTO = _mapper.Map<List<BookDTO>>(books);
            return booksDTO;
        }

        public async Task<List<BookDTO>> GetAllBooksWithAuthors()
        {
            var books = await _bookRepository.GetAuthorsWithBooksAsync();
            var booksDTO = _mapper.Map<List<BookDTO>>(books);
            return booksDTO;
        }

        public async Task<List<BookDTO>> CreateBookAsync(CreateBookDTO book)
        {
            var bookEntity = _mapper.Map<Book>(book);
            await _bookRepository.CreateAsync(bookEntity);
            await _bookRepository.SaveAsync();
            var books = await _bookRepository.GetAllAsync();
            var booksDTO = _mapper.Map<List<BookDTO>>(books);
            return booksDTO;
        }

        public async Task<List<AuthorInBookDTO>> AddAuthorsToBook(Guid bookId, List<Guid> authorIds)
        {
            var bookToUpdate = await _bookRepository.FindByIdAsync(bookId);
            List<Author> authorsFromDbList = await _authorRepository.FindRangeAsync(authorIds);

            List<AuthorInBook> authorInBookList = new();

            foreach (var author in authorsFromDbList)
            {
                var newAuthorInBook = new AuthorInBook
                {
                    Author = author,
                    Book = bookToUpdate
                };
                authorInBookList.Add(newAuthorInBook);
            }
            await _authorInBookRepository.CreateRangeAsync(authorInBookList);
            await _authorInBookRepository.SaveAsync();

            var authorWithBook = await _bookRepository.GetAuthorsWithBooksAsync();
            return _mapper.Map<List<AuthorInBookDTO>>(authorWithBook);
        }

    }


}
