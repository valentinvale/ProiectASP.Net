namespace ProiectASPNET.Models.DTOs
{
    public class UpdateQuoteDTO
    {
        public Guid Id { get; set; } // pui id-ul quote-ului pe care vrei sa il modifici
        public string Text { get; set; } // putem sa modificam doar text si notes ca sa nu se schimbe id-ul user-ului si id-ul cartii

        public string? Notes { get; set; }

    }
}
