namespace ProiectASPNET.Models.DTOs
{
    public class CreateQuoteOfTheMonthDTO
    {
        public Guid QuoteId { get; set; }
        public string Month { get; set; }
        public string Impressions { get; set; }
    }
}
