namespace ProiectASPNET.Models.DTOs
{
    public class LeaderboardDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public QuoteOfTheMonthDTO QuoteOfTheMonth { get; set; }
    }
}
