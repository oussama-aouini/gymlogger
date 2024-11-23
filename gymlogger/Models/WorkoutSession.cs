namespace gymlogger.Models
{
    public class WorkoutSession
    {
        public int Id { get; set; }
        public DateTime StartTime { get; set; } = DateTime.Now;
        public DateTime EndTime { get; set; }

        // One-to-Many: WorkoutSession can have many Sets
        public List<Set> Sets { get; set; } = new List<Set>();

        // Many-to-Many: WorkoutSession can have many Exercises independently of the WorkoutTemplate
        public List<Exercise> Exercises { get; set; } = new List<Exercise>();

        // One to many user:workoutSession props
        public string AppUserId { get; set; } = null!;
        public AppUser AppUser { get; set; } = null!;
    }
}
