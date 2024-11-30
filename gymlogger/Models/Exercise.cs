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

        // Many-to-Many: Exercise can belong to many WorkoutTemplates
        public List<WorkoutTemplate> WorkoutTemplates { get; set; } = new List<WorkoutTemplate>();

        // Many-to-Many: Exercise can belong to many WorkoutSessions independently of any template
        public List<Session> Sessions { get; set; } = new List<Session>();
    }
}
