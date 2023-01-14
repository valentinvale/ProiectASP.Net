namespace ProiectASPNET.Models.DTOs
{
    public class QuoteDTO
    {
        public Guid Id { get; set; }
        public string Text { get; set; }

        public Guid userId { get; set; }
    }
}
