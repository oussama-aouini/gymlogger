using gymlogger.Models;

namespace gymlogger.Interfaces
{
    public interface IRoutineRepository
    {
        Task<List<Routine>> GetUserRoutines(string userId);
        Task<List<Exercise>> GetRoutineExercices(int routineId);

    }
}
