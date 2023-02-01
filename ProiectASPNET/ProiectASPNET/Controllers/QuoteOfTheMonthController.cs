using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProiectASPNET.Models.DTOs;
using ProiectASPNET.Services.QuoteOfTheMonthService;

namespace ProiectASPNET.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuoteOfTheMonthController : ControllerBase
    {
        public readonly IQuoteOfTheMonthService _quoteOfTheMonthService;

        public QuoteOfTheMonthController(IQuoteOfTheMonthService quoteOfTheMonthService)
        {
            _quoteOfTheMonthService = quoteOfTheMonthService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllQuoteOfTheMonth()
        {
            var quoteOfTheMonth = await _quoteOfTheMonthService.GetAllQuoteOfTheMonth();
            return Ok(quoteOfTheMonth);
        }

        [HttpPost]
        public async Task<IActionResult> CreateQuoteOfTheMonth([FromBody] CreateQuoteOfTheMonthDTO quoteOfTheMonth)
        {
            var quotesOfTheMonth = await _quoteOfTheMonthService.CreateQuoteOfTheMonthAsync(quoteOfTheMonth);
            return Ok(quotesOfTheMonth);
        }
    }
}
