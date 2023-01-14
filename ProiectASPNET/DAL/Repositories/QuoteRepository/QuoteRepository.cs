using ProiectASPNET.Data;
using ProiectASPNET.Models;
using ProiectASPNET.Repositories.GenericRepository;

namespace DAL.Repositories.QuoteRepository
{
    public class QuoteRepository : GenericRepository<Quote>, IQuoteRepository
    {
        public QuoteRepository(ProjectContext context) : base(context)
        {
        }
    }
    
}
