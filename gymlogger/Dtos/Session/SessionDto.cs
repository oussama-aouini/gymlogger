using gymlogger.Dtos.Set;

namespace gymlogger.Dtos.Session
{
    public class SessionDto
    {
        public int Id { get; set; }
        public DateTime StartTime { get; set; } = DateTime.Now;
        public DateTime EndTime { get; set; }

        // One-to-Many: WorkoutSession can have many Sets
        public List<SetDto> Sets { get; set; } = [];
    }
}
