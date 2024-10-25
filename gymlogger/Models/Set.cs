namespace gymlogger.Models
{
    public class Set
    {
        public int Id { get; set; }
        public float Weight { get; set; }
        public int Repetitions { get; set; }
        public int? WorkoutId { get; set; }
        // Navigation property
        public WorkoutSession? WorkoutSession { get; set; }
    }
}
