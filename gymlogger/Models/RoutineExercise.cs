namespace gymlogger.Models
{
    //Joint Table
    public class RoutineExercise
    {
        public int RoutineId { get; set; }
        public int ExerciseId { get; set; }

        // Navigatio props (these props are for the
        // developer they take no part in making the relationship between tables )
        public required Routine Routine { get; set; }
        public required Exercise Exercise { get; set; }
    }
}
