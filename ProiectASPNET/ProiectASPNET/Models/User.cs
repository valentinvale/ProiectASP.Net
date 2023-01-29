using ProiectASPNET.Models.Base;
using ProiectASPNET.Models.enums;
using System.Text.Json.Serialization;

namespace ProiectASPNET.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        [JsonIgnore]
        public string PasswordHash { get; set; }

        public Role Role { get; set; }

    }
}
