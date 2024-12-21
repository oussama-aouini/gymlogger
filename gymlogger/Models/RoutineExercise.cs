using System.ComponentModel.DataAnnotations.Schema;

namespace gymlogger.Models
{
    //Joint Table
    [Table("RoutineExercises")]
    public class RoutineExercise
    {
        public int RoutineId { get; set; }
        public int ExerciseId { get; set; }

        // Navigatio props (these props are for the
        // developer they take no part in making the relationship between tables )
        public Routine Routine { get; set; } = null!;
        public Exercise Exercise { get; set; } = null!;
    }
}
