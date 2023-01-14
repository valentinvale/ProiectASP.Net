using ProiectASPNET.Models;
using ProiectASPNET.Models.DTOs;

namespace ProiectASPNET.Services.QuoteService
{
    public interface IQuoteService
    {
        Task<List<QuoteDTO>> GetAllQuotes();
    }
}
