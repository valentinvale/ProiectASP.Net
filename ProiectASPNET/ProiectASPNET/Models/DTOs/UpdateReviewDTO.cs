namespace ProiectASPNET.Models.DTOs
{
    public class UpdateReviewDTO
    {
        public Guid Id { get; set; }
        public string HeadLine { get; set; }
        public string? Text { get; set; }
        public int Rating { get; set; }
    }
}
