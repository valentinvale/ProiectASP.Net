using AutoMapper;
using ProiectASPNET.Models;
using ProiectASPNET.Models.DTOs;
using ProiectASPNET.Repositories.BookRepository;

namespace ProiectASPNET.Services.BookService
{
    public class BookService : IBookService
    {
        public readonly IBookRepository _bookRepository;
        public readonly IMapper _mapper;

        public BookService(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public async Task<List<BookDTO>> GetAllBooks()
        {
            var books = await _bookRepository.GetBooksWithReviewsAsync();
            //var books = await _bookRepository.GetAllAsync();
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
    }


}
