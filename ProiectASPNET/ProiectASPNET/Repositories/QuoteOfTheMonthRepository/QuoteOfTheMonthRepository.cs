using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using ProiectASPNET.Data;
using ProiectASPNET.Models;
using ProiectASPNET.Repositories.GenericRepository;

namespace ProiectASPNET.Repositories.QuoteOfTheMonthRepository
{
    public class QuoteOfTheMonthRepository : GenericRepository<QuoteOfTheMonth>, IQuoteOfTheMonthRepository
    {
        public QuoteOfTheMonthRepository(ProjectContext context) : base(context)
        {
        }

        public async Task<List<QuoteOfTheMonth>> GetAllQuoteOfTheMonth()
        {
            return await _table.Include(q => q.Quote).ToListAsync();
        }
    }
}
