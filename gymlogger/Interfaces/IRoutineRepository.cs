using gymlogger.Models;

namespace gymlogger.Interfaces
{
    public interface IRoutineRepository
    {
        // Todo: Task<List<Routine>> GetUserRoutines(AppUser user);
        Task<List<Exercise>> GetRoutineExercices(int routineId);

    }
}
