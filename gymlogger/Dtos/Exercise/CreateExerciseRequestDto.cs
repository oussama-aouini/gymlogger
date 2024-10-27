using gymlogger.Enums;

namespace gymlogger.Dtos.Exercise
{
    public class CreateExerciseRequestDto
    {
        public string Name { get; set; } = string.Empty;
        public List<Muscle> Muscles { get; set; } = new List<Muscle>();
    }
}
