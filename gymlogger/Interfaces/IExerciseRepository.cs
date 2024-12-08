using gymlogger.Dtos.Exercise;
using gymlogger.Helpers;
using gymlogger.Models;

namespace gymlogger.Interfaces
{
    public interface IExerciseRepository
    {
        Task<List<Exercise>> GetAllAsync(GetExercisesQueryObject query);
        Task<Exercise?> GetByIdAsync(int id);
        Task<Exercise> CreateAsync(Exercise exerciseModel);
        Task<Exercise?> UpdateAsync(int id, UpdateExerciseRequestDto exerciseDto);
        Task<Exercise?> DeleteAsync(int id);
    }
}
