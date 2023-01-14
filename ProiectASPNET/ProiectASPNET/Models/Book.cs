using ProiectASPNET.Models.Base;

namespace ProiectASPNET.Models
{
    public class Book : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string ISBN { get; set; }
        public string CoverUrl { get; set; }
        public string Publisher { get; set; }
        public string Genre { get; set; }
        public int? NumberOfPages { get; set; }
        public DateTime? DatePublished { get; set; }
        public DateTime? DatePublishedOnSite { get; set; }
        public virtual ICollection<AuthorInBook> AuthorsLink { get; set; }
        public virtual ICollection<Review>? Reviews { get; set; }
    }
    
}
