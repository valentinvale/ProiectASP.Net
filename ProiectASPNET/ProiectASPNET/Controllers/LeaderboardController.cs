using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProiectASPNET.Models.DTOs;
using ProiectASPNET.Services.LeaderboardService;

namespace ProiectASPNET.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaderboardController : ControllerBase
    {
        public readonly ILeaderboardService _leaderboardService;

        public LeaderboardController(ILeaderboardService leaderboardService)
        {
            _leaderboardService = leaderboardService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllLeaderboard()
        {
            var leaderboard = await _leaderboardService.GetAllLeaderboard();
            return Ok(leaderboard);
        }

        [HttpPost]
        public async Task<IActionResult> CreateLeaderboardAsync(CreateLeaderboardDTO leaderboard)
        {
            var leaderboards = await _leaderboardService.CreateLeaderboardAsync(leaderboard);
            return Ok(leaderboards);
        }

        /*
        [HttpPost("updateLeaderboard")]
        public async Task<IActionResult> UpdateLeaderboardAsync(UpdateLeaderboardDTO leaderboard)
        {
            var leaderboard = await _leaderboardService.UpdateLeaderboardAsync(leaderboard);
            return Ok(leaderboard);
        }
        */
    }
}
