using gymlogger.Data;
using gymlogger.Interfaces;
using gymlogger.Models;
using Microsoft.EntityFrameworkCore;

namespace gymlogger.Repository
{
    public class RoutineRepository : IRoutineRepository
    {
        private readonly ApplicationDBContext _context;

        public RoutineRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task AddExerciseToRoutine(int routineId, int exerciseId)
        {
            await _context.RoutineExercises.AddAsync(new RoutineExercise { RoutineId = routineId, ExerciseId = exerciseId });
            await _context.SaveChangesAsync();
        }

        public async Task<List<Exercise>> GetRoutineExercicesAsync(int routineId)
        {
            return await _context.RoutineExercises.Where(r => r.RoutineId == routineId)
                .Select(x => new Exercise
                {
                    Id = x.ExerciseId,
                    Muscles = x.Exercise.Muscles,
                    Name = x.Exercise.Name,
                    Sets = x.Exercise.Sets,
                }).ToListAsync();
        }

        public async Task<List<Routine>> GetUserRoutines(string userId)
        {
            return await _context.Routines.Where(r => r.AppUserId ==  userId).ToListAsync();
        }

        public async Task<RoutineExercise?> RemoveExerciseFromRoutineAsync(int routineId, int exerciseId)
        {
            var routineExercise = await _context.RoutineExercises.FirstOrDefaultAsync(x => x.ExerciseId == exerciseId && x.RoutineId == routineId);

            if (routineExercise == null)
            {
                return null;
            }

            _context.RoutineExercises.Remove(routineExercise);
            await _context.SaveChangesAsync();
            return routineExercise;
        }
    }
}
