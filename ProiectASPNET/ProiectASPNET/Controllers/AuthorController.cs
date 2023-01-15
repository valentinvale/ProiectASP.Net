using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        [HttpPost]

        public async Task<IActionResult> PostAuthor([FromBody] CreateAuthorDTO author)
        {
            await _authorService.CreateAuthorAsync(author);
            return Ok(author);
        }

    }
}
