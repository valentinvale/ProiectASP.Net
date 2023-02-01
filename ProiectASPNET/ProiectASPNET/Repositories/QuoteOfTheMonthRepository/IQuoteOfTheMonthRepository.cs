using ProiectASPNET.Models;
using ProiectASPNET.Repositories.GenericRepository;

namespace ProiectASPNET.Repositories.QuoteOfTheMonthRepository
{
    public interface IQuoteOfTheMonthRepository : IGenericRepository<QuoteOfTheMonth>
    {
        public Task<List<QuoteOfTheMonth>> GetAllQuoteOfTheMonth();
    }
}
