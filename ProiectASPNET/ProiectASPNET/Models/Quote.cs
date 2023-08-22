using ProiectASPNET.Models.Base;

namespace ProiectASPNET.Models
{
    public class Quote : BaseEntity
    {
        public string Text { get; set; } // citatul
        public string Notes { get; set; } // adaugam un camp unde utilizatorul poate sa isi noteze cum interpreteaza citatul

        public string Username { get; set; } // adaugam un camp pentru a stoca username-ul userului care a adaugat citatul
        public Guid UserId { get; set; }

        public Guid BookId { get; set; }

        public Book Book { get; set; }
        // putem sa adaugam si un camp cu like-uri (valabil si la review)

    }
}


