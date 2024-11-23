using gymlogger.Enums;

namespace gymlogger.Dtos.Set
{
    public class SetDto
    {
        public int Id { get; set; }
        public float Weight { get; set; }
        public int Repetitions { get; set; }
        public SetType SetType { get; set; }
        public int WorkoutSessionId { get; set; }
        public int ExerciseId { get; set; }
    }
}
