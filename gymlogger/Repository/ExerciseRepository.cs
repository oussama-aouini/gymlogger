using gymlogger.Data;
using gymlogger.Dtos.Exercise;
using gymlogger.Helpers;
using gymlogger.Interfaces;
using gymlogger.Models;
using Microsoft.EntityFrameworkCore;

namespace gymlogger.Repository
{
    public class ExerciseRepository : IExerciseRepository
    {
        private readonly ApplicationDBContext _context;
        public ExerciseRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Exercise> CreateAsync(Exercise exerciseModel)
        {
            await _context.Exercises.AddAsync(exerciseModel);
            await _context.SaveChangesAsync();
            return exerciseModel;
        }

        public async Task<Exercise?> DeleteAsync(int id)
        {
            var exerciseModel = await _context.Exercises.FirstOrDefaultAsync(e => e.Id == id);

            if (exerciseModel == null)
            {
                return null;
            }

            _context.Remove(exerciseModel);

            await _context.SaveChangesAsync();

            return exerciseModel; 
        }

        public async Task<List<Exercise>> GetAllAsync(GetExercisesQueryObject query)
        {
            var exercises = _context.Exercises.AsQueryable();

            if(query.Muscle.HasValue)
            {
                exercises = exercises.Where(e => e.Muscles.Contains(query.Muscle.Value));
            }

            return await exercises.ToListAsync();
        }

        public async Task<Exercise?> GetByIdAsync(int id)
        {
            return await _context.Exercises.FindAsync(id);
        }

        public async Task<Exercise?> UpdateAsync(int id, UpdateExerciseRequestDto exerciseDto)
        {
            var exerciseModel = await _context.Exercises.FirstOrDefaultAsync(e => e.Id == id);

            if (exerciseModel == null)
            {
                return null;
            }

            exerciseModel.Name = exerciseDto.Name;
            exerciseModel.Muscles = exerciseDto.Muscles;

            await _context.SaveChangesAsync();

            return exerciseModel;
        }
    }
}
