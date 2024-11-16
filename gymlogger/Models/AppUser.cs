using Microsoft.AspNetCore.Identity;

namespace gymlogger.Models
{
    public class AppUser : IdentityUser
    {
        public DateTime Birthday { get; set; }
        public float Weight { get; set; }
        public float Height { get; set; }
    }
}
