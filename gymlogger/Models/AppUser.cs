using Microsoft.AspNetCore.Identity;

namespace gymlogger.Models
{
    public class AppUser : IdentityUser
    {
        public DateTime Birthday { get; set; }
        public float Weight { get; set; }
        public float Height { get; set; }

        // one to many props
        public List<WorkoutTemplate> WorkoutTemplates { get; set; } = new List<WorkoutTemplate>();
        public List<WorkoutSession> WorkoutSessions { get; set; } = new List<WorkoutSession>();
        public List<Set> Sets { get; set; } = new List<Set>();

    }
}
