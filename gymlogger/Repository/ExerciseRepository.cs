using gymlogger.Data;
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

        public async Task<List<Exercise>> GetAllAsync()
        {
            return await _context.Exercises.ToListAsync();
        }
    }
}
