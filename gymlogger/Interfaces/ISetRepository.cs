using gymlogger.Models;

namespace gymlogger.Interfaces
{
    public interface ISetRepository
    {
        Task<List<Set>> GetSetsBySessionIdAsync(string userId,int workoutSessionId);
        Task<List<Set>> GetSetsByExerciseIdAsync(string userId, int exerciseId);
        Task<Set> AddAsync(Set set);
        Task<Set?> UpdateAsync(int id, Set set);
    }
}