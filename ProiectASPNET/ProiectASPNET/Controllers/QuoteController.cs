using Microsoft.AspNetCore.Http;
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

        [HttpPost("update/{bookId}")]
        public async Task<IActionResult> UpdateQuote([FromRoute] Guid bookId, [FromBody] UpdateQuoteDTO quote)
        {
            await _quoteService.UpdateQuoteAsync(bookId, quote);
            return Ok(quote);
        }

        [HttpDelete("{quoteId}")]
        public async Task<IActionResult> DeleteQuote([FromRoute] Guid quoteId)
        {
            await this._quoteService.DeleteQuote(quoteId);
            return Ok(await _quoteService.GetAllQuotes());
        }
    }
}
