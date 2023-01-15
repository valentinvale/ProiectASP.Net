﻿using Microsoft.AspNetCore.Http;
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
            // return Ok(await _bookService.GetAllBooks()); // cu review-uri
            return Ok(await _bookService.GetAllBooksWithAuthors()); // cu autori, nu merge inca
        }


        [HttpPost]
        public async Task<IActionResult> PostBook([FromBody] CreateBookDTO book)
        {
            await _bookService.CreateBookAsync(book);
            return Ok(book);
        }

        [HttpPost ("{bookId}")]
        public async Task<IActionResult> AddAuthorsToBook(Guid bookId, [FromBody] List<Guid> authorIds)
        {
            await _bookService.AddAuthorsToBook(bookId, authorIds);
            return Ok();
        }
    }
}
