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
            return await _table.Include(l => l.QuoteOfTheMonth).ToListAsync();
        }
    }
    
}
