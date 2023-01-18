using System.Collections;

namespace ProiectASPNET.Models.DTOs
{
    public class AuthorAndReviewInBook
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string ISBN { get; set; }
        public string CoverUrl { get; set; }
        public string Publisher { get; set; }
        public string Genre { get; set; }
        public int? NumberOfPages { get; set; }
        public DateTime? DatePublished { get; set; }
        public ICollection<AuthorDTO> Authors { get; set; }
        public ICollection<ReviewDTO> Reviews { get; set; }

        public ICollection<QuoteDTO> Quotes { get; set; }
    }
}
