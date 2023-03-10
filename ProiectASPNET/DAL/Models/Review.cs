using ProiectASPNET.Models.Base;

namespace ProiectASPNET.Models
{
    public class Review : BaseEntity
    {
        public string Headline { get; set; }
        public string? ReviewText { get; set; }
        public int Rating { get; set; }
        public Guid BookId { get; set; }
        public Book Book { get; set; }
        // o sa adaugam si un camp pentru a stoca id-ul userului care a facut review-ul
        // si un camp cu username-ul userului care a facut review-ul
    }

}
