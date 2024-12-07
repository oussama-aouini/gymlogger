using gymlogger.Enums;

namespace gymlogger.Dtos.Set
{
    public class UpdateSetRequestDto
    {
        public float Weight { get; set; }
        public int Repetitions { get; set; }
        public SetType SetType { get; set; }
    }
}
