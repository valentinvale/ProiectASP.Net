namespace ProiectASPNET.Models.DTOs
{
    public class AuthorDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string FullName => $"{FirstName} {LastName}";

        public string Description { get; set; }


    }
}
