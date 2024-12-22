using gymlogger.Models;

namespace gymlogger.Interfaces
{
    public interface IRoutineRepository
    {
        Task<List<Routine>> GetUserRoutines(string userId);
        Task<List<Exercise>> GetRoutineExercicesAsync(int routineId);
        Task AddExerciseToRoutine(int routineId, int exerciseId);
        Task<RoutineExercise?> RemoveExerciseFromRoutineAsync(int routineId, int exerciseId);
    }
}
