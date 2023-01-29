using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProiectASPNET.Models;
using ProiectASPNET.Models.DTOs;
using ProiectASPNET.Repositories.BookRepository;
using ProiectASPNET.Services.BookService;

namespace ProiectASPNET.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        public readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBooks()
        {
            var books = await _bookService.GetAllBooks();
            return Ok(books);
        }

        // fara reviews & quotes, nu stiu daca e nevoie totusi
        [HttpGet("NoRQ")]
        public async Task<IActionResult> GetAllBooksNoRQ()
        {
            var books = await _bookService.GetAllBooksNoRQ();
            return Ok(books);
        }


        [HttpGet("getBooksWithAuthors")]

        public async Task<IActionResult> GetAllBooksWithAuthors()
        {
            return Ok(await _bookService.GetAllBooksWithAuthors()); // cu autori
        }

        [HttpGet("getBooksWithReviews")]
        public async Task<IActionResult> GetBooksWithReviews()
        {
            return Ok(await _bookService.GetAllBooksWithReviews()); // cu review-uri
        }

        [HttpGet("getBooksByAuthorId/{authorId}")]
        public async Task<IActionResult> GetBooksByAuthorId(Guid authorId)
        {
            return Ok(await _bookService.GetBooksByAuthorId(authorId));
        }

        [HttpGet("getBooksByAuthorName/{authorName}")]
        public async Task<IActionResult> GetBooksByAuthorName(string authorName)
        {
            return Ok(await _bookService.GetBooksByAuthorName(authorName));
        }

        [HttpGet("getBookById/{bookId}")]
        public async Task<IActionResult> GetBookById(Guid bookId)
        {
            return Ok(await _bookService.GetBookById(bookId));
        }

        [HttpGet("getBookByTitle/{bookTitle}")]
        public async Task<IActionResult> GetBookByTitle(string bookTitle)
        {
            return Ok(await _bookService.GetBooksByTitle(bookTitle));
        }

        [HttpGet("getBookByGenre/{bookGenre}")]
        public async Task<IActionResult> GetBookByGenre(string bookGenre)
        {
            return Ok(await _bookService.GetBooksByGenre(bookGenre));
        }

        [HttpGet("getBookByISBN/{ISBN}")]
        public async Task<IActionResult> GetBooksByISBN(string isbn)
        {
            return Ok(await _bookService.GetBooksByISBN(isbn));
        }

        [HttpPost]
        public async Task<IActionResult> PostBook([FromBody] CreateBookDTO book)
        {
            await _bookService.CreateBookAsync(book);
            return Ok(book);
        }

        [HttpPost("addAuthorsToBook/{bookId}")]
        public async Task<IActionResult> AddAuthorsToBook(Guid bookId, [FromBody] List<Guid> authorIds)
        {
            return Ok(await _bookService.AddAuthorsToBook(bookId, authorIds));

        }

        [HttpPost("update")]
        public async Task<IActionResult> UpdateBook([FromBody] UpdateBookDTO book)
        {
            await _bookService.UpdateBookAsync(book);
            return Ok(book);
        }

        [HttpDelete("{bookId}")]

        public async Task<IActionResult> DeleteBook([FromRoute] Guid bookId)
        {
            await this._bookService.DeleteBook(bookId);
            return Ok(await _bookService.GetAllBooks());
        }
    }
}