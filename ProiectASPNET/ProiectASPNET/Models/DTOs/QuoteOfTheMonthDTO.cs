namespace ProiectASPNET.Models.DTOs
{
    public class QuoteOfTheMonthDTO
    {
        public Guid Id { get; set; }
        public QuoteDTO Quote { get; set; }
        public string Month { get; set; }
        public string Impressions { get; set; }
    }
}
