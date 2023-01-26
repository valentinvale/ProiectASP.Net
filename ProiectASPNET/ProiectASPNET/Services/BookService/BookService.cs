using AutoMapper;
using ProiectASPNET.Models;
using ProiectASPNET.Models.DTOs;
using ProiectASPNET.Repositories.AuthorInBookRepository;
using ProiectASPNET.Repositories.AuthorRepository;
using ProiectASPNET.Repositories.BookRepository;
using ProiectASPNET.Repositories.QuoteRepository;
using ProiectASPNET.Repositories.ReviewRepository;

namespace ProiectASPNET.Services.BookService
{
    public class BookService : IBookService
    {
        public readonly IBookRepository _bookRepository;
        public readonly IAuthorRepository _authorRepository;
        private readonly IAuthorInBookRepository _authorInBookRepository;
        public readonly IReviewRepository _reviewRepository;
        public readonly IQuoteRepository _quoteRepository;
        public readonly IMapper _mapper;
        private object authorInBookRepository;

        public BookService(IBookRepository bookRepository, IMapper mapper, IAuthorInBookRepository authorInBookRepository, IAuthorRepository authorRepository, IReviewRepository reviewRepository, IQuoteRepository quoteRepository)
        {
            _bookRepository = bookRepository;
            _authorRepository = authorRepository;
            _authorInBookRepository = authorInBookRepository;
            _reviewRepository = reviewRepository;
            _quoteRepository = quoteRepository;
            _mapper = mapper;
        }

        public async Task<List<BookDTO>> GetAllBooksWithReviews()
        {
            var books = await _bookRepository.GetBooksWithReviewsAsync();
            //var books = await _bookRepository.GetAllAsync();
            var booksDTO = _mapper.Map<List<BookDTO>>(books);
            return booksDTO;
        }

        public async Task<List<AuthorInBookDTO>> GetAllBooksWithAuthors()
        {
            var books = await _bookRepository.GetAuthorsWithBooksAsync();
            var booksDTO = _mapper.Map<List<AuthorInBookDTO>>(books);
            return booksDTO;
        }

        public async Task<List<AuthorAndReviewInBook>> GetAllBooks()
        {
            var books = await _bookRepository.GetAllWithBooksAsync();
            var booksDTO = _mapper.Map<List<AuthorAndReviewInBook>>(books);
            return booksDTO;
        }

        public async Task<List<AuthorAndReviewInBook>> GetBooksByAuthorId(Guid authorId)
        {
            var books = await _bookRepository.GetBooksByAuthorId(authorId);
            var booksDTO = _mapper.Map<List<AuthorAndReviewInBook>>(books);
            return booksDTO;
        }

        public async Task<List<AuthorAndReviewInBook>> GetBooksByAuthorName(string authorName)
        {
            var books = await _bookRepository.GetBooksByAuthorName(authorName);
            var booksDTO = _mapper.Map<List<AuthorAndReviewInBook>>(books);
            return booksDTO;
        }

        public async Task<List<AuthorAndReviewInBook>> GetBookById(Guid bookId)
        {
            var books = await _bookRepository.GetBooksById(bookId);
            var booksDTO = _mapper.Map<List<AuthorAndReviewInBook>>(books);
            return booksDTO;
        }

        public async Task<List<AuthorAndReviewInBook>> GetBooksByTitle(string bookTitle)
        {
            var books = await _bookRepository.GetBooksByTitle(bookTitle);
            var booksDTO = _mapper.Map<List<AuthorAndReviewInBook>>(books);
            return booksDTO;
        }

        public async Task<List<AuthorAndReviewInBook>> GetBooksByGenre(string bookGenre)
        {
            var books = await _bookRepository.GetBooksByGenre(bookGenre);
            var booksDTO = _mapper.Map<List<AuthorAndReviewInBook>>(books);
            return booksDTO;
        }

        public async Task<List<AuthorAndReviewInBook>> GetBooksByISBN(string isbn)
        {
            var books = await _bookRepository.GetBooksByISBN(isbn);
            var booksDTO = _mapper.Map<List<AuthorAndReviewInBook>>(books);
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

        // ar trebui si o functie de remove authors from book  

            public async Task UpdateBookAsync(UpdateBookDTO book)
        {
            // aparent merge si pastreaza review-urile fara sa trebuiasca sa mai facem ceva in plus
            _bookRepository.Update(_mapper.Map<Book>(book));
            await _bookRepository.SaveAsync();
        }

        public async Task DeleteBook(Guid bookId)
        {
            var book = await _bookRepository.FindByIdAsync(bookId);
            if(book != null)
            {
                var reviews = book.Reviews;
                var quotes = book.Quotes;
                // functioneaza nush dc
                if(reviews != null)
                    foreach (var review in reviews)
                    {
                        _reviewRepository.Delete(review);
                    }

                if (quotes != null)
                    foreach (var quote in quotes)
                    {
                        _quoteRepository.Delete(quote);
                    }

                _bookRepository.Delete(book);
                await _bookRepository.SaveAsync();
            }
            
        }

    }

    


}
