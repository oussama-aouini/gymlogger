using gymlogger.Enums;

namespace gymlogger.Models
{
    public class Exercise
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<Muscle> Muscles { get; set; } = new List<Muscle>();
    }
}
