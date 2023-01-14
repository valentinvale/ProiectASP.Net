using ProiectASPNET.Models.Base;

namespace ProiectASPNET.Models
{
    public class Quote : BaseEntity
    {
        public string Text { get; set; }
        public int UserId { get; set; }
        
    }
}
