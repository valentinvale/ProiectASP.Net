using ProiectASPNET.Models.DTOs;

namespace ProiectASPNET.Services.QuoteOfTheMonthService
{
    public interface IQuoteOfTheMonthService
    {
        public Task<List<QuoteOfTheMonthDTO>> GetAllQuoteOfTheMonth();
        public Task<List<QuoteOfTheMonthDTO>> CreateQuoteOfTheMonthAsync(CreateQuoteOfTheMonthDTO quoteOfTheMonth);
    }
}
