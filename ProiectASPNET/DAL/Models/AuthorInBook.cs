namespace ProiectASPNET.Models
{
    public class AuthorInBook
    {
        public Guid AuthorId { get; set; }
        public Author Author { get; set; }
        public Guid BookId { get; set; }
        public Book Book { get; set; }
        
    }
}
