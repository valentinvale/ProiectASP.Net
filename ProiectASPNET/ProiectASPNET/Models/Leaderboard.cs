using ProiectASPNET.Models.Base;

namespace ProiectASPNET.Models
{
    public class Leaderboard : BaseEntity
    {
        public string Name { get; set; }

        public Guid QuoteOfTheMonthId { get; set; }
        public QuoteOfTheMonth QuoteOfTheMonth { get; set; }
    }
}
