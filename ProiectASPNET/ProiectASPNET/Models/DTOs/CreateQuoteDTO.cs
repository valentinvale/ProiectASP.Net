namespace ProiectASPNET.Models.DTOs
{
    public class CreateQuoteDTO
    {
        public string Text { get; set; }

        public string Notes { get; set; }

        public string Username { get; set; }

        public Guid UserId { get; set; }

        public Guid BookId { get; set; }

    }
}
