namespace gymlogger.Models
{
    public class Routine
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        // Many-to-Many: WorkoutTemplate can have many Exercises
        public List<Exercise> Exercises { get; set; } = new List<Exercise>();

        // One to many user:WorkoutTemplate props
        public string AppUserId { get; set; } = null!;
        public AppUser AppUser { get; set; } = null!;
    }
}
