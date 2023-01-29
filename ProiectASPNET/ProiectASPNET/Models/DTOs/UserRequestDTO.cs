using System.ComponentModel.DataAnnotations;

namespace ProiectASPNET.Models.DTOs
{
    public class UserRequestDTO
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

    }
}
