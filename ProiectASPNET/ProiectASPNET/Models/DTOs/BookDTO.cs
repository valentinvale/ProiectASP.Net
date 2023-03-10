namespace ProiectASPNET.Models.DTOs
{
    public class BookDTO
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string CoverUrl { get; set; }
        public string Publisher { get; set; }
        public string Genre { get; set; }

        public string ISBN { get; set; }

        public virtual ICollection<AuthorDTO> Authors { get; set; }
        public virtual ICollection<ReviewDTO>? Reviews { get; set; }

        public virtual ICollection<QuoteDTO>? Quotes { get; set; }

    }
}
