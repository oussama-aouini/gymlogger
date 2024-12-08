namespace gymlogger.Models
{
    public class Routine
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        // One to many user:WorkoutTemplate props
        public string AppUserId { get; set; } = null!;
        public AppUser AppUser { get; set; } = null!;

        // Many-to-Many Routine and Exercise
        public List<RoutineExercise> RoutineExercise { get; set; } = new List<RoutineExercise>();
    }
}
