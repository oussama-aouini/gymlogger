using gymlogger.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace gymlogger.Data
{
    public class ApplicationDBContext : IdentityDbContext<AppUser>
    {
        public ApplicationDBContext(DbContextOptions dbContextOptions)
            : base(dbContextOptions)
        {
            
        }

        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<Set> Sets { get; set; }
        public DbSet<WorkoutSession> WorkoutSessions { get; set; }
        public DbSet<WorkoutTemplate> workoutsTemplates { get; set; }
    }
}
