using ProiectASPNET.Models.Base;

namespace ProiectASPNET.Models
{
    public class Review : BaseEntity
    {
        public string Headline { get; set; }
        public string ReviewText { get; set; }
        public int Rating { get; set; }
        public Guid BookId { get; set; }
        public Book Book { get; set; }
    }
    
}
