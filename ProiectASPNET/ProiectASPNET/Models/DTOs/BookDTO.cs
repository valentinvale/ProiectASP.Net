namespace ProiectASPNET.Models.DTOs
{
    public class BookDTO
    {
        public Guid Id { get; set; }
        public Guid Title { get; set; }
        public string Description { get; set; }
        public string CoverUrl { get; set; }
        public string Publisher { get; set; }
        public string Genre { get; set; }
        public virtual ICollection<AuthorInBook> AuthorsLink { get; set; }
        public virtual ICollection<Review>? Reviews { get; set; }

    }
}
