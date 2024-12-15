using System.ComponentModel.DataAnnotations.Schema;

namespace gymlogger.Models
{
    [Table("Sessions")]
    public class Session
    {
        public int Id { get; set; }
        public DateTime StartTime { get; set; } = DateTime.Now;
        public DateTime EndTime { get; set; }

        // One-to-Many: Session can have many Sets
        public List<Set> Sets { get; set; } = new List<Set>();

        // One to many user props
        public string AppUserId { get; set; } = null!;
        public AppUser AppUser { get; set; } = null!;
    }
}
