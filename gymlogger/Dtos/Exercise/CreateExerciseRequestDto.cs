using gymlogger.Enums;
using System.ComponentModel.DataAnnotations;

namespace gymlogger.Dtos.Exercise
{
    public class CreateExerciseRequestDto
    {
        [Required]
        [MinLength(5, ErrorMessage = "Exercise name must be at least 5 characters")]
        [MaxLength(50, ErrorMessage = "Exercise name cannot be over 50 characters")]
        public string Name { get; set; } = string.Empty;
        public List<Muscle> Muscles { get; set; } = new List<Muscle>();
    }
}
