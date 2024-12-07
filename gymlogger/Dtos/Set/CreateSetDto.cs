using gymlogger.Enums;

namespace gymlogger.Dtos.Set
{
    public class CreateSetDto
    {
        public float Weight { get; set; }
        public int Repetitions { get; set; }
        public SetType SetType { get; set; }
        public int SessionId { get; set; }
        public required string UserId { get; set; }
        public int ExerciseId { get; set; }
    }
}
