using gymlogger.Enums;

namespace gymlogger.Models
{
    public class Set
    {
        // I can use either null! or required 

        public int Id { get; set; }
        public float Weight { get; set; }
        public int Repetitions { get; set; }

        // Foreign Key to WorkoutSession
        public int WorkoutSessionId { get; set; }
        public required WorkoutSession WorkoutSession { get; set; } // Navigation property

        // Foreign Key to Exercise
        public int ExerciseId { get; set; }
        public Exercise Exercise { get; set; } = null!; // null-forgiving operator used when relationship is mandatory and we will have the information from the database at runtime in a nutshell it tells the compiler don't worrt it won't be null

        // One to many user:set props
        public int UserId { get; set; }
        public AppUser User { get; set; } = null!;
    }
}
