using ProiectASPNET.Models;
using ProiectASPNET.Models.DTOs;

namespace ProiectASPNET.Services.QuoteService
{
    public interface IQuoteService
    {
        Task<List<QuoteDTO>> GetAllQuotes();

        Task<List<QuoteDTO>> CreateQuoteAsync(CreateQuoteDTO quote);

        Task UpdateQuoteAsync(Guid bookId, UpdateQuoteDTO quote);
        Task DeleteQuote(Guid quoteId);
    }
}
