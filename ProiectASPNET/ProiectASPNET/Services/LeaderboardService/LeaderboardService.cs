using AutoMapper;
using ProiectASPNET.Models;
using ProiectASPNET.Models.DTOs;
using ProiectASPNET.Repositories.LeaderboardRepository;

namespace ProiectASPNET.Services.LeaderboardService
{
    public class LeaderboardService : ILeaderboardService
    {
        public readonly ILeaderboardRepository _leaderboardRepository;
        public readonly IMapper _mapper;

        public LeaderboardService(ILeaderboardRepository leaderboardRepository, IMapper mapper)
        {
            _leaderboardRepository = leaderboardRepository;
            _mapper = mapper;
        }
        
        public async Task<List<LeaderboardDTO>> GetAllLeaderboard()
        {
            var leaderboards = await _leaderboardRepository.GetLeaderboard();
            var leaderboardsDTO = _mapper.Map<List<LeaderboardDTO>>(leaderboards);
            return leaderboardsDTO;
            
        }

        public async Task<List<LeaderboardDTO>> CreateLeaderboardAsync(CreateLeaderboardDTO leaderboard)
        {
            var leaderboardEntity = _mapper.Map<Leaderboard>(leaderboard);
            await _leaderboardRepository.CreateAsync(leaderboardEntity);
            await _leaderboardRepository.SaveAsync();
            var leaderboards = await _leaderboardRepository.GetLeaderboard();
            var leaderboardsDTO = _mapper.Map<List<LeaderboardDTO>>(leaderboards);
            return leaderboardsDTO;
        }

    }
}
