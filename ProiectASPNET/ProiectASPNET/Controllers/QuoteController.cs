﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProiectASPNET.Models.DTOs;
using ProiectASPNET.Services.QuoteService;

namespace ProiectASPNET.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuoteController : ControllerBase
    {
        public readonly IQuoteService _quoteService;

        public QuoteController(IQuoteService quoteService)
        {
            _quoteService = quoteService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllQuotes()
        {
            var quotes = await _quoteService.GetAllQuotes();
            return Ok(quotes);
        }

        [HttpPost]
        public async Task<IActionResult> PostQuote([FromBody] CreateQuoteDTO quote)
        {
            await _quoteService.CreateQuoteAsync(quote);
            return Ok(quote);
        }
    }
}
