using gymlogger.Enums;
using System.ComponentModel.DataAnnotations;

namespace gymlogger.Dtos.Set
{
    public class UpdateSetRequestDto
    {
        [Required]
        [Range(0, 1000)]
        public float Weight { get; set; }
        [Required]
        [Range(0, 200)]
        public int Repetitions { get; set; }
        public SetType SetType { get; set; }
    }
}
