using gymlogger.Models;

namespace gymlogger.Interfaces
{
    public interface IExerciseRepository
    {
        Task<List<Exercise>> GetAllAsync();
    }
}
