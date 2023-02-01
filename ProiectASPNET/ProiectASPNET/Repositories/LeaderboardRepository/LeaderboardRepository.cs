using Microsoft.EntityFrameworkCore;
using ProiectASPNET.Data;
using ProiectASPNET.Models;
using ProiectASPNET.Repositories.GenericRepository;

namespace ProiectASPNET.Repositories.LeaderboardRepository
{
    public class LeaderboardRepository : GenericRepository<Leaderboard>, ILeaderboardRepository
    {
        public LeaderboardRepository(ProjectContext context) : base(context)
        {
        }

        public async Task<List<Leaderboard>> GetLeaderboard()
        {
            return await _table.Include(l => l.QuoteOfTheMonth).Select(l => new Leaderboard
            {
                Id = l.Id,
                Name = l.Name,
                QuoteOfTheMonth = new QuoteOfTheMonth
                {
                    Id = l.QuoteOfTheMonth.Id,
                    Quote = l.QuoteOfTheMonth.Quote,
                    Month = l.QuoteOfTheMonth.Month,
                    Impressions = l.QuoteOfTheMonth.Impressions
                }
            }).ToListAsync();
        }
    }
    
}
