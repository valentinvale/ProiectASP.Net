using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProiectASPNET.Models;
using ProiectASPNET.Models.DTOs;
using ProiectASPNET.Services.AuthorService;

namespace ProiectASPNET.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        public readonly IAuthorService _authorService;

        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAuthors()
        {
            var authors = await _authorService.GetAllAuthors();
            return Ok(authors);
        }

        [HttpGet("getAuthorsById/{authorId}")]

        public async Task<IActionResult> GetAuthorById([FromRoute] Guid authorId)
        {
            var authors = await _authorService.GetAuthorsById(authorId);
            return Ok(authors);
        }

        [HttpGet("getAuthorsByName/{authorName}")]
        public async Task<IActionResult> GetAuthorByName([FromRoute] string authorName)
        {
            var authors = await _authorService.GetAuthorsByName(authorName);
            return Ok(authors);
        }

        [HttpGet("getAuthorsByBookId/{bookId}")]
        public async Task<IActionResult> GetAuthorByBookId([FromRoute] Guid bookId)
        {
            var authors = await _authorService.GetAuthorsByBookId(bookId);
            return Ok(authors);
        }

        [HttpGet("getAuthorsByBookName/{bookName}")]
        public async Task<IActionResult> GetAuthorByBookName([FromRoute] string bookName)
        {
            var authors = await _authorService.GetAuthorsByBookName(bookName);
            return Ok(authors);
        }

        [HttpPost]

        public async Task<IActionResult> PostAuthor([FromBody] CreateAuthorDTO author)
        {
            await _authorService.CreateAuthorAsync(author);
            return Ok(author);
        }


        [HttpPost("update")]
        public async Task<IActionResult> UpdateAuthor([FromBody] UpdateAuthorDTO author)
        {
            await _authorService.UpdateAuthorAsync(author);
            return Ok(author);
        }

        [HttpDelete("{authorId}")]
        public async Task<IActionResult> DeleteAuthor([FromRoute] Guid authorId)
        {
            await this._authorService.DeleteAuthor(authorId);
            return Ok(await _authorService.GetAllAuthors());
        }

    }
}
