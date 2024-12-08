using gymlogger.Enums;

namespace gymlogger.Models
{
    public class Exercise
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<Muscle> Muscles { get; set; } = new List<Muscle>();

        // One-to-Many: Exercise can have many Sets
        public List<Set> Sets { get; set; } = new List<Set>();

        // Many-to-Many Routine and Exercise
        public List<RoutineExercise> RoutineExercise { get; set; } = new List<RoutineExercise>();

    }
}
