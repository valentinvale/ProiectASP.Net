namespace ProiectASPNET.Models.DTOs
{
    public class QuoteDTO
    {
        public Guid Id { get; set; }
        public string Text { get; set; }

        public string Notes { get; set; }

        public Guid UserId { get; set; }

        public Guid BookId { get; set; }

    }
}
