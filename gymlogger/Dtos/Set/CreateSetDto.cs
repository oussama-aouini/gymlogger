using gymlogger.Enums;
using System.ComponentModel.DataAnnotations;

namespace gymlogger.Dtos.Set
{
    public class CreateSetDto
    {
        [Required]
        [Range(0, 1000)]
        public float Weight { get; set; }
        [Required]
        [Range(0, 200)]
        public int Repetitions { get; set; }
        public SetType SetType { get; set; }
        public int SessionId { get; set; }
        public required string UserId { get; set; }
        public int ExerciseId { get; set; }
    }
}
