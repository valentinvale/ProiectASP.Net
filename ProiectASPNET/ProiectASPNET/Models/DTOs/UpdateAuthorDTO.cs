namespace ProiectASPNET.Models.DTOs
{
    public class UpdateAuthorDTO
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Description { get; set; }
    }
}
