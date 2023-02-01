using ProiectASPNET.Models.DTOs;

namespace ProiectASPNET.Services.LeaderboardService
{
    public interface ILeaderboardService
    {
        public Task<List<LeaderboardDTO>> GetAllLeaderboard();
        public Task<List<LeaderboardDTO>> CreateLeaderboardAsync(CreateLeaderboardDTO leaderboard);
    }
}
