using Microsoft.AspNetCore.Identity;

namespace gymlogger.Models
{
    public class AppUser : IdentityUser
    {
        public DateTime Birthday { get; set; }
        public float Weight { get; set; }
        public float Height { get; set; }

        // one to many props
        public List<Routine> Routines { get; set; } = new List<Routine>();
        public List<Session> Sessions { get; set; } = new List<Session>();
        public List<Set> Sets { get; set; } = new List<Set>();

    }
}
