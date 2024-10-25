namespace gymlogger.Models
{
    public class WorkoutSession
    {
        public int Id { get; set; }
        public DateTime StartTime { get; set; } = DateTime.Now;
        public DateTime EndTime { get; set; }
        public List<Set> Sets { get; set; } = new List<Set>();
    }
}
