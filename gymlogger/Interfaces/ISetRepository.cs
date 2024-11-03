using gymlogger.Models;

namespace gymlogger.Interfaces
{
    public interface ISetRepository
    {
        Task<List<Set>> GetSetsByWorkoutSessionIdAsync(int workoutSessionId);
        Task<List<Set>> GetSetsByExerciseIdAsync(int exerciseId);
        Task<Set> AddAsync(Set set);
        Task<Set?> UpdateAsync(int id, Set set);
    }
}