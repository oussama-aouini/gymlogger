using gymlogger.Models;
using Microsoft.EntityFrameworkCore;

namespace gymlogger.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions dbContextOptions)
            : base(dbContextOptions)
        {
            
        }

        DbSet<Exercise> Exercises { get; set; }
        DbSet<Set> Sets { get; set; }
        DbSet<WorkoutSession> WorkoutSessions { get; set; }
        DbSet<WorkoutTemplate> workoutsTemplates { get; set; }
    }
}
