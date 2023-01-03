using ProiectASPNET.Models.Base;

namespace ProiectASPNET.Models
{
    public class Author : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => $"{FirstName} {LastName}";
        public string Description { get; set; }
        public virtual ICollection<AuthorInBook> BooksLink { get; set; }
    }
    
}
