using gymlogger.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace gymlogger.Models
{
    [Table("Set")]
    public class Set
    {
        // I can use either null! or required 

        public int Id { get; set; }
        public float Weight { get; set; }
        public int Repetitions { get; set; }
        public SetType SetType { get; set; }

        // Foreign Key to WorkoutSession
        public int SessionId { get; set; }
        public Session Session { get; set; } = null!; // Navigation property

        // Foreign Key to Exercise
        public int ExerciseId { get; set; }
        public Exercise Exercise { get; set; } = null!; // null-forgiving operator used when relationship is mandatory and we will have the information from the database at runtime in a nutshell it tells the compiler don't worrt it won't be null

        // One to many user:set props
        public string AppUserId { get; set; } = null!;
        public AppUser AppUser { get; set; } = null!;
    }
}
