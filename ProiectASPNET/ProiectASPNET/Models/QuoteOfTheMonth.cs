using ProiectASPNET.Models.Base;

namespace ProiectASPNET.Models
{
    public class QuoteOfTheMonth : BaseEntity
    {
        public Guid QuoteId { get; set; }
        public Quote Quote { get; set; }
        public string Month { get; set; }
        public string Impressions { get; set; }

        public Leaderboard Leaderboard { get; set; }
    }
}
