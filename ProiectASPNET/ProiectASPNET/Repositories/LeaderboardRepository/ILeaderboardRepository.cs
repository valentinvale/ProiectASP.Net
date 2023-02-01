using ProiectASPNET.Models;
using ProiectASPNET.Repositories.GenericRepository;

namespace ProiectASPNET.Repositories.LeaderboardRepository
{
    public interface ILeaderboardRepository : IGenericRepository<Leaderboard>
    {
        public Task<List<Leaderboard>> GetLeaderboard();
    }
}
