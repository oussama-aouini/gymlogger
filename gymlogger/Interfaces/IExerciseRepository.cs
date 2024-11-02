using gymlogger.Dtos.Exercise;
using gymlogger.Models;

namespace gymlogger.Interfaces
{
    public interface IExerciseRepository
    {
        Task<List<Exercise>> GetAllAsync();
        Task<Exercise?> GetByIdAsync(int id);
        Task<Exercise> CreateAsync(Exercise exerciseModel);
        Task<Exercise?> UpdateAsync(int id, UpdateExerciseRequestDto exerciseDto);
        Task<Exercise?> DeleteAsync(int id);
    }
}
