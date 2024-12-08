using gymlogger.Models;
using Microsoft.AspNetCore.Identity;
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

        public required DbSet<Exercise> Exercises { get; set; }
        public required DbSet<Set> Sets { get; set; }
        public required DbSet<Session> Sessions { get; set; }
        public required DbSet<Routine> Routines { get; set; }
        public required DbSet<RoutineExercise> RoutineExercises { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<RoutineExercise>(x => x.HasKey(p => new { p.RoutineId, p.ExerciseId }));

            builder.Entity<RoutineExercise>()
                .HasOne(u => u.Exercise)
                .WithMany(u => u.RoutineExercise)
                .HasForeignKey(u => u.ExerciseId);

            builder.Entity<RoutineExercise>()
                .HasOne(u => u.Routine)
                .WithMany(u => u.RoutineExercise)
                .HasForeignKey(u => u.RoutineId);

            builder.Entity<Session>()
            .HasOne(ws => ws.AppUser)
            .WithMany(u => u.Sessions)
            .HasForeignKey(ws => ws.AppUserId)
            .OnDelete(DeleteBehavior.Restrict);

            List<IdentityRole> roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Name = "Admin",
                    NormalizedName = "ADMIN",
                },
                new IdentityRole
                {
                    Name = "User",
                    NormalizedName = "USER",
                }
            };
            builder.Entity<IdentityRole>().HasData(roles);
        }
    }
}
